// TODO: Need to move this url.
const urlRootApi = 'http://localhost:51224/api';
let msg = "";

$(function () {
    PatientSchedule.Interface.initUI();
});

var PatientSchedule = {
    Interface: {
        initUI() {
            PatientSchedule.Interface.EventsButtons();
            PatientSchedule.Interface.loadTypeDates();
            PatientSchedule.Interface.loadPatient();
            PatientSchedule.Interface.addSelectionList();
        },
        EventsButtons: function () {
            $('#btnCreate').click(function () {
                PatientSchedule.Business.assignment();
            });     
            $('#btnSearch').click(function () {
                PatientSchedule.Business.listDates();
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


        },
        datesGrid: function (data) {            
            records = data;
            console.log(records);
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
                                .addClass('btn btn-primary')
                                .click(function () {
                                    PatientSchedule.Business.cancel(item);
                                });
                        } 
                    }
                ]
            });

        },
        loadTypeDates() {
            PatientSchedule.Server.getTypeDate();
        },
        loadPatient() {
            PatientSchedule.Server.getPatient();
        },
        loadSelectInput(data) {

            $("#type").empty();
            //$("#type").append($("<option></option>").val("-1").html("Seleccionar un tipo"));

            for (let i = 0; i < data.length; i++) {
                $('#type').append($('<option>', {
                    value: data[i].Id,
                    text: data[i].Name
                }));
            }
        },
        loadSelectPatient(data) {

            let optionList = PatientSchedule.Interface.createOptions(data);

            $('#patient').selectize({
                maxItems: 1,
                valueField: 'id',
                labelField: 'title',
                searchField: 'title',
                options: optionList,
                create: false
            });

        },
        createOptions(data) {
            let entityList = [];
            for (let i = 0; i < data.length; i++) {
                let entity = {
                    id: data[i].Id,
                    title: data[i].Name,
                    url: ""
                };
                entityList.push(entity);
            }
            return entityList;
        },
        cleanForm() {
            //$("#patient").val("");
            $("#datebook").val("");
            $("#description").val("");
            $("#type").val("");
        }
    },    
    Business: {
        listDates() {            
            // Validation fields, if true then call api.
            let idPatient = $("#patient").val();

            if (idPatient === '') {
                idPatient = -1;
            }

            PatientSchedule.Server.getDateId(idPatient);
        },
        assignment() {
            
            if (!PatientSchedule.Business.isCompleteFieldsFormDates()) {
                return false;
            }
                        
            let entity = PatientSchedule.Business.createEntity();
            PatientSchedule.Server.postDate(entity);
        },
        cancel(schedule) {
            $.confirm({
                title: 'Confirmar!',
                content: '¿Desea cancelar esta cita?',
                buttons: {
                    confirm: function () {
                        PatientSchedule.Server.deleteDate(schedule.Id);
                    },
                    cancel: function () {
                        //$.alert('Canceled!');
                    },
                 }
            });
            
            console.log("cancel");
        },
        isCompleteFieldsFormDates() {
            let idPatient = $("#idPatient").val();

            if (idPatient === '') {
                PatientSchedule.Messages.invalidField("Id Paciente");
                return false;
            }

            if ($("#datebook").val() === '') {
                PatientSchedule.Messages.invalidField("Fecha Cita");
                return false;
            }
            if ($("#type").val() === '-1') {
                PatientSchedule.Messages.invalidField("Tipo Cita");
                return false;
            }
                       
            return true;
        },
        validationMinimunHoursCancelation() {
            PatientSchedule.Messages.invalidMinimunDate();
            return false;
        },
        validationSameDaySamePatient() {
            PatientSchedule.Messages.invalidDateByDay();
            return false;
        },
        createEntity() {                                    
            //entity.type = $("#type").val();  
            let entity = {
                IdPatient: $("#patient").val(),
                datebook: $("#datebook").val(),
                IdTypeDates: $("#type").val(),
                description: $("#description").val()
            };
            return JSON.stringify(entity);
        },
        okPost() {
            PatientSchedule.Interface.cleanForm();
            PatientSchedule.Messages.okPost();
        },
        errorPost(data) {
            PatientSchedule.Messages.errorServer(data.responseJSON.Message);
        },
        okCancel() {
            PatientSchedule.Business.listDates();
            PatientSchedule.Messages.okCancel();
        },
        errorCancel(data) {
            PatientSchedule.Messages.errorServer(data.responseJSON.Message);
        },
        okGet(data) {
            PatientSchedule.Interface.datesGrid(data);
            //PatientSchedule.Messages.okGet();
        },
        errorGet() {
            PatientSchedule.Messages.errorGet();
        }
    },
    Server: {
        getDates() {            
            let urlRootApi = `/Schedule/`;
            PatientSchedule.Server.callApi(urlRootApi, "GET", PatientSchedule.Business.okGet, PatientSchedule.Business.errorGet, null);
        },
        getDateId(idPatient) {
            let urlRootApi = `/Schedule/${idPatient}`;
            PatientSchedule.Server.callApi(urlRootApi, "GET", PatientSchedule.Business.okGet, PatientSchedule.Business.errorGet, null);
        },
        getTypeDate() {
            let urlRootApi = `/TypeSchedule/`;
            PatientSchedule.Server.callApi(urlRootApi, "GET", PatientSchedule.Interface.loadSelectInput, PatientSchedule.Business.errorGet, null);
        },
        getPatient() {
            let urlRootApi = `/Patient/`;
            PatientSchedule.Server.callApi(urlRootApi, "GET", PatientSchedule.Interface.loadSelectPatient, PatientSchedule.Business.errorGet, null);
        },
        postDate(entity) {            
            let urlRootApi = `/Schedule/`;
            PatientSchedule.Server.callApi(urlRootApi, "POST", PatientSchedule.Business.okPost, PatientSchedule.Business.errorPost, entity);
        },        
        deleteDate(Id) {
            let urlRootApi = `/Schedule/${Id}`;
            PatientSchedule.Server.callApi(urlRootApi, "DELETE", PatientSchedule.Business.okCancel, PatientSchedule.Business.errorCancel, null);
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
                error: function (data) {
                    functionErrorApi(data);
                }
            });
        }
    },
    Messages: {        
        okPost() {
            msg = "El ingreso de la cita fue realizado exitosamente.";
            PatientSchedule.Messages.callMessage();
        },
        okCancel() {
            msg = "La cita fue cancelada exitosamente.";
            PatientSchedule.Messages.callMessage();
        },
        errorGet(data) {
            msg = "Ocurrio un error en la consulta.";
            PatientSchedule.Messages.callMessage();
        },
        errorServer(data) {
            msg = data;
            PatientSchedule.Messages.callMessage();
        },
        invalidMinimunDate() {
            msg = "La cita solo se puede cancelar con un minimo de 24 horas de anticipación.";
            PatientSchedule.Messages.callMessage();
        },
        invalidDateByDay() {
            msg = "El paciente ya cuenta con una cita para esta fecha.";
            PatientSchedule.Messages.callMessage();
        },
        invalidField(field) {
            msg = `El campo ${field} es requerido.`;
            PatientSchedule.Messages.callMessage();
        },
        callMessage() {
            //TODO: Implementation component notification.
            $.alert({
                title: 'Eureka!',
                content: msg,
            });
        }
    }
};