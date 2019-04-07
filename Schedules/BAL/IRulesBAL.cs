using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IRulesBAL<T>
    {
        object Get();


        IEnumerable<object> GetList();

        void Delete();

        void Insert();

    }
}
