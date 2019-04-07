using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAL.Context
{
    public interface IRepositorio<T>
    {
        IEnumerable<T> GetLists();
        T GetById(int id);
        void Insert(T entidad);
        void Update(T entidad);
        void Delete(int id);
    }
}
