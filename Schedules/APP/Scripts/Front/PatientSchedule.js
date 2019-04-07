// TODO: Need to move this url.
const urlRootApi = 'http://localhost:55209/api';
let msg = "";


$(function () {
    PatientDates.Interface.initUI();
});

var PatientDates = {
    Interface: {
        initUI() {
            PatientDates.Interface.EventsButtons();
            PatientDates.Interface.loadTypeDates();
            PatientDates.Interface.addSelectionList();
        },
        EventsButtons: function () {
            $('#btnCreate').click(function () {
                PatientDates.Business.assignment();
            });     
            $('#btnSearch').click(function () {
                PatientDates.Business.listDates();
            });                 
            $("#PatientDate").datepicker();
            $("#datebook").datepicker();            
        },
        printGridPatients(data) {
            console.log("data print");
        },
        printPatientDates(data) {
            console.log("data print");
        },
        addSelectionList() {
            $('#idPatient').selectize({
                create: true,
                sortField: {
                    field: 'text',
                    direction: 'asc'
                },
                dropdownParent: 'body'
            });

        },
        datesGrid: function (data) {            
            records = data;
            console.log(records);
            var countries = [
                { Description: "1", Id: 0 },
                { Description: "United States", Id: 1 }
            ];

            $("#jsGrid").jsGrid({
                width: "100%",
                height: "200px",

                inserting: false,
                editing: false,
                sorting: false,
                paging: false,
                deleteConfirm: "¿Esta seguro de cancelar la cita?",

                data: records,

                fields: [
                    //{ type: "control" },
                    { name: "Id", type: "text", width: 150 },
                    { name: "Description", type: "text", width: 150 },
                    {
                        headerTemplate: function () {

                        }
                        , itemTemplate: function (value, item) {
                            return $("<input>").prop("type", "button")
                                .val("Cancelar")
                                .click(function () {
                                    PatientDates.Business.cancel(item);
                                });
                        } 
                    }
                ]
            });

        },
        loadTypeDates() {
            PatientDates.Server.getTypeDate();
        },
        loadSelectInput(data) {
            debugger;
            //let listaSeleccionada = $("#type").val();
            $("#type").empty();
            $("#type").append($("<option></option>").val("-1").html(""));

            for (let i = 0; i < response.Records.length; i++) {
                $("#type").append($("<option></option>").val(response.Records[i].id).html(response.Records[i].name));
            }
            //$("#type").val(idSelected);
        }
    },    
    Business: {
        listDates() {            
            // Validation fields, if true then call api.
            let idPatient = $("#idPatientSearch").val();

            if (idPatient === '') {
                idPatient = -1;
            }

            PatientDates.Server.getDateId(idPatient);
        },
        assignment() {
            
            if (!PatientDates.Business.isCompleteFieldsFormDates()) {
                return false;
            }
                        
            let entity = PatientDates.Business.createEntity();
            PatientDates.Server.postDate(entity);
        },
        cancel(idDatabook) {
            let idPatient = $("#idPatient").val();
            PatientDates.Server.deleteDate(idPatient);
            console.log("cancel");
        },
        isCompleteFieldsFormDates() {
            let idPatient = $("#idPatient").val();

            if (idPatient === '') {
                PatientDates.Messages.invalidField("Id Paciente");
                return false;
            }

            if ($("#datebook").val() === '') {
                PatientDates.Messages.invalidField("Fecha Cita");
                return false;
            }

            if ($("#type").val() === '-1') {
                PatientDates.Messages.invalidField("Tipo Cita");
                return false;
            }
                       
            return true;
        },
        validationMinimunHoursCancelation() {
            PatientDates.Messages.invalidMinimunDate();
            return false;
        },
        validationSameDaySamePatient() {
            PatientDates.Messages.invalidDateByDay();
            return false;
        },
        createEntity() {                                    
            //entity.type = $("#type").val();            
            let entity = { id: $("#idPatient").val(), datebook: $("#datebook").val(), description: $("#description").val()};
            return JSON.stringify(entity);
        },
        cleanForm() {
            $("#idPatient").val("");
            $("#datebook").val("");
            $("#description").val("");
            $("#type").val("");
        },
        okPost() {
            PatientDates.Messages.okPost();
        },
        errorPost() {
            PatientDates.Messages.errorPost();
        },
        okCancel() {
            PatientDates.Messages.okCancel();
        },
        errorCancel() {
            PatientDates.Messages.errorCancel();
        },
        okGet(data) {
            PatientDates.Interface.datesGrid(data);
            //PatientDates.Messages.okGet();
        },
        errorGet() {
            PatientDates.Messages.errorGet();
        }
    },
    Server: {
        getDates() {            
            let urlRootApi = `/Dates/`;
            PatientDates.Server.callApi(urlRootApi, "GET", PatientDates.Business.okGet, PatientDates.Business.errorGet, null);
        },
        getDateId(idPatient) {
            let urlRootApi = `/Dates/${idPatient}`;
            PatientDates.Server.callApi(urlRootApi, "GET", PatientDates.Business.okGet, PatientDates.Business.errorGet, null);
        },
        getTypeDate() {
            debugger;
            let urlRootApi = `/TypeDates/`;
            PatientDates.Server.callApi(urlRootApi, "GET", PatientDates.Interface.loadSelectInput, PatientDates.Business.errorGet, null);
        },
        postDate(entity) {            
            let urlRootApi = `/Dates/`;
            PatientDates.Server.callApi(urlRootApi, "POST", PatientDates.Business.okPost, PatientDates.Server.errorPost, entity);
        },        
        deleteDate(ID) {
            let urlRootApi = `/Dates/${idPatient}`;
            PatientDates.Server.callApi(urlRootApi, "DELETE", PatientDates.Business.okCancel, PatientDates.Business.errorCancel, entity);
        },
        errorComunication(data) {
            console.log("error connection API");
        },
        callApi: function (urlApi, typeCall, functionApi, functionErrorApi, entity) {
            $.ajax({
                url: urlRootApi + urlApi,
                type: typeCall,                
                data: entity,                
                contentType: 'application/json',
                dataType: 'json',
                success: function (data) {
                    functionApi(data);
                },
                error: function () {
                    functionErrorApi();
                }
            });
        }
    },
    Messages: {        
        okPost() {
            msg = "El ingreso de la cita due realizado exitosamente.";
            PatientDates.Messages.callMessage();
        },
        okCancel() {
            msg = "La de la cita fue realizada exitosamente.";
            PatientDates.Messages.callMessage();
        },
        errorPost() {
            msg = "Ocurrio un error en el agendamiento.";
            PatientDates.Messages.callMessage();
        },
        errorCancel() {
            msg = "Ocurrio un error en la cancelación.";
            PatientDates.Messages.callMessage();
        },
        errorGet() {
            msg = "Ocurrio un error en la consulta.";
            PatientDates.Messages.callMessage();
        },
        invalidMinimunDate() {
            msg = "La cita solo se puede cancelar con un minimo de 24 horas de anticipación.";
            PatientDates.Messages.callMessage();
        },
        invalidDateByDay() {
            msg = "El paciente ya cuenta con una cita para esta fecha.";
            PatientDates.Messages.callMessage();
        },
        invalidField(field) {
            msg = `El campo ${field} es requerido.`;
            PatientDates.Messages.callMessage();
        },
        callMessage() {
            //TODO: Implementation component notification.
            alert(msg);
        }
    }
};