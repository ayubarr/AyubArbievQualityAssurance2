using AyubArbievQualityAssurance2.Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using QualityAssurance2.Data.DataBase.SqlServer;
using QualityAssurance2.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityAssurance2.Data.Repositories.Implementations
{
    public class Repository<T> : IExist, IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext ContextDb;

        public Repository(AppDbContext context)
        {
            ContextDb = context;
        }

        public bool DataBaseExist()
        {
            DbSet<T> TestSet = ContextDb.Set<T>();
            if (TestSet == default(DbSet<T>))
                return true;

            return false;
        }

        public T Add(T item)
        {
            if (DataBaseExist()) return default(T);
            T result = ContextDb.Set<T>().Add(item).Entity;
            ContextDb.SaveChanges();
            return result;
        }

        public void Delete(T item)
        {
            if (DataBaseExist()) return;
            ContextDb.Set<T>().Remove(item);
            ContextDb.SaveChanges();
        }

        public List<T> GetAll()
        {
            if (DataBaseExist()) return default(List<T>);
            return ContextDb.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            if (DataBaseExist())return default(T);
            T entity = ContextDb.Set<T>().FirstOrDefault(z => z.Id.Equals(id));
            return entity;
        }

        public void Update(T Item)
        {
            if (DataBaseExist())return;
            ContextDb.Set<T>().Update(Item);
            ContextDb.SaveChanges();
        }
      

    }
}
