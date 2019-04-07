using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAL.Context
{
    interface IValidations<T>
    {
        T GetSchedulesSameDay(int id, DateTime datebook);
        T GetScheduleToCancel(int id, DateTime datebook);
    }
}
