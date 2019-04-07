using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace SAL.Context
{
    public class RepositoryTypeDates<T> : IRepositorio<T> where T : TypeSchedule, new()
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
            using (var db = new ContextSAL())
            {
                var typeList = db.Set<T>().ToList();
                return typeList;
            }
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
