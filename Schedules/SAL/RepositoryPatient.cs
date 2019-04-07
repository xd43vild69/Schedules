using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace SAL.Context
{
    public class RepositoryPatient<T> : IRepositorio<T> where T : Entity, new()
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetLists()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(T entidad)
        {
            throw new NotImplementedException();
        }
    }
}
