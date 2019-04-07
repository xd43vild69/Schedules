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
        private ScheduleValidation<Schedule> Validations { get; set; }
        private int Id { get; set; }
        private Schedule Schedule { get; set; }

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

        public void Delete()
        {
            //TODO: validation needed before Delete it.
            Repository.Delete(Schedule.Id);
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
    }
}
