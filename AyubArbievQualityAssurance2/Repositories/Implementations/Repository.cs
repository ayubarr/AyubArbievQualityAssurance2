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
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext ContextDb;

        public Repository(AppDbContext context)
        {
            ContextDb = context;
        }
        public T Add(T item)
        {
            DbSet<T> dbSet = ContextDb.Set<T>();

            if (dbSet == default(DbSet<T>))
                return default(T);

            T result = dbSet.Add(item).Entity;
            ContextDb.SaveChanges();

            return result;
        }

        public void Delete(T item)
        {
            ExistenceCheck();
            ContextDb.Set<T>().Remove(item);
            ContextDb.SaveChanges();
        }

        public List<T> GetAll()
        {
            DbSet<T> dbSet = ContextDb.Set<T>();

            if (dbSet == default(DbSet<T>))
                return default(List<T>);

            return dbSet.ToList();
        }

        public T GetById(int id)
        {
            DbSet<T> dbSet = ContextDb.Set<T>();
            if (dbSet == default(DbSet<T>))
                return default(T);

            T entity = dbSet.FirstOrDefault(z => z.Id.Equals(id));
            return entity;
        }

        public void Update(T Item)
        {
            DbSet<T> dbSet  = ExistenceCheck();
            dbSet.Update(Item);
            ContextDb.SaveChanges();
        }
        public DbSet<T> ExistenceCheck()
        {
            DbSet<T> TestSet = ContextDb.Set<T>();
            if (TestSet == default(DbSet<T>))
                return null;

            return TestSet;
        }

    }
}
