using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using SAL.Context;
namespace BAL
{
    public class ScheduleBAL
    {
        private ScheduleRepository<Schedule> Repository { get; set;}

        public ScheduleBAL()
        {
            Repository = new ScheduleRepository<Schedule>();
        }

        public Schedule GetDates(int idPatient)
        {
            return Repository.GetById(idPatient);
        }

        public IEnumerable<Schedule> GetByIdPatient(int idPatient)
        {
            return Repository.GetByIdPatient(idPatient);
        }


        public void Delete(int idPatient)
        {
            //TODO: validation needed before Delete it.
            Repository.Delete(idPatient);
        }

        public void Insert(Schedule schedule)
        {
            //TODO: validation needed before Insert it.
            Repository.Insert(schedule);
        }

        /// <summary>
        /// Valid that the date is greater than 24 hours.
        /// Basic example to complex business logic here.
        /// Need UnitTest call.
        /// </summary>
        /// <param name="idPatient">Identifier</param>
        /// <returns>True if the process could continue.</returns>
        public bool IsDateValidToCancel(int idPatient)
        {
            return true;
        }

        /// <summary>
        /// Patient can be schedule a date if exist another date the same day.
        /// Basic example to complex business logic here.
        /// Need UnitTest call.
        /// </summary>
        /// <param name="idPatient">Identifier</param>
        /// <param name="datebook">Time to schedule</param>
        /// <returns>True if the process could continue.</returns>
        public bool IsPatientWithDatesSameDay(int idPatient, DateTime datebook)
        {
            return true;
        }
    }
}
