using DTO;
using SAL.Context;
using System.Collections.Generic;

namespace BAL
{
    public class TypeScheduleBAL
    {
        public TypeScheduleRepository<TypeSchedule> Repository { get; set; }

        public TypeScheduleBAL()
        {
            Repository = new TypeScheduleRepository<TypeSchedule>();
        }
        public IEnumerable<TypeSchedule> GetLists()
        {
            return Repository.GetLists();
        }
    }
}
