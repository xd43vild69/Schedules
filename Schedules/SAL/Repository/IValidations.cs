using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAL.Context
{
    interface IValidations<T>
    {
        T GetSchedulesSameDay(int id);
        T GetScheduleToCancel(int id);
    }
}
