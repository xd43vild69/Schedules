using SAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace SAL.Context
{
    public class ScheduleValidation<T> : IValidations<T> where T : Schedule, new()
    {
        public T GetSchedulesSameDay(int id, DateTime datebook)
        {
            using (var db = new ContextSAL())
            {
                return db.Set<T>().FirstOrDefault(x => x.IdPatient == id && x.Datebook == datebook);
            }
        }

        public T GetScheduleToCancel(int id, DateTime datebook)
        {
            using (var db = new ContextSAL())
            {
                return db.Set<T>().FirstOrDefault(x => x.Id == id && x.Datebook <= datebook.AddDays(-1));
            }
        }
    }
}
