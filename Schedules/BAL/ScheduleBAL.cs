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
            //TODO: validation needed before Insert it.
            Repository.Insert(Schedule);
        }
    }
}
