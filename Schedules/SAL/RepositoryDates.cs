using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace SAL.Context
{
    public class RepositoryDates<T> : IRepositorio<T> where T : Dates, new()
    {
        public void Delete(int id)
        {
            using (var db = new SALContext())
            {
                var entity = new T() { Id = id };
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public T GetById(int id)
        {
            using (var db = new SALContext())
            {
                return db.Set<T>().FirstOrDefault(x => x.Id == id);
            }
        }

        public IEnumerable<T> GetByIdPatient(int id)
        {
            using (var db = new SALContext())
            {
                var datesList = db.Set<T>().Where(x => x.IdPatient == id).ToList();
                return datesList;
            }
        }

        public IEnumerable<T> GetLists()
        {
            using (var db = new SALContext())
            {
                return db.Set<T>().ToList(); 
            }
        }

        public void Insert(T entity)
        {
            using (var db = new SALContext())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Update(T entidad)
        {
            throw new NotImplementedException();
        }
    }
}
