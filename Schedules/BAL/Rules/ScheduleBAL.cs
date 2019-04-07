using DTO;
using SAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class ScheduleBAL : IRulesBAL<ScheduleBAL>
    {
        private ScheduleRepository<Schedule> Repository { get; set; }
        private IValidations<Schedule> Validations { get; set; }
        private int Id { get; set; }
        private Schedule Schedule { get; set; }
        const int HOURSTOCANCEL = 24;

        public ScheduleBAL()
        {
            Repository = new ScheduleRepository<Schedule>();
        }

        public ScheduleBAL(object entity)
        {
            Schedule = (Schedule)entity;
            Repository = new ScheduleRepository<Schedule>();
            Validations = new ScheduleValidation<Schedule>();
        }

        public ScheduleBAL(IValidations<Schedule> validation)
        {
            Validations = validation;
        }

        public void Delete()
        {
            if (IsValidToCancel(Schedule.Id, Schedule.Datebook))
            {
                Repository.Delete(Schedule.Id);
            }
            else
            {
                throw new ApplicationException("La cita no puede cancelarse.");
            }
        }

        public object Get()
        {
            return Repository.GetByIdPatient(Schedule.Id);
        }

        public IEnumerable<object> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            if(IsValidedCreateSchedule(Schedule.IdPatient, Schedule.Datebook))
            {
                Repository.Insert(Schedule);
            }else
            {
                throw new ApplicationException("La cita no puede programarse para está fecha.");
            }
        }

        /// <summary>
        /// Validation schedule same day rule.
        /// </summary>
        /// <param name="id">Identify Pacient</param>
        /// <param name="datebook">Datetime schedule</param>
        /// <returns>True when process can continue.</returns>
        public bool IsValidedCreateSchedule(int id, DateTime datebook)
        {
            bool isValid = true;
            var schedulesDay = Validations.GetSchedulesSameDay(id, datebook);
            if (schedulesDay != null || datebook < System.DateTime.Now)
            {
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// Validation schedule can to cancel.
        /// </summary>
        /// <param name="id">Id Schedule</param>
        /// <param name="datebook">Datime schedule</param>
        /// <returns>True when process can continue.</returns>
        public bool IsValidToCancel(int id, DateTime datebook)
        {
            bool isValid = true;
            
            var schedules = Validations.GetScheduleToCancel(id, datebook);
            if (schedules != null && schedules.Datebook.AddHours(-HOURSTOCANCEL) < DateTime.Now) 
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
