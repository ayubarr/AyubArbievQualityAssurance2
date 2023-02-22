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
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public T Add(T item)
        {
            DbSet<T> dbSet = _context.Set<T>();

            if (dbSet == default(DbSet<T>))
                return default(T);

            T result = dbSet.Add(item).Entity;
            _context.SaveChanges();

            return result;
        }

        public void Delete(T item)
        {
            DbSet<T> dbSet = _context.Set<T>();
            if (dbSet == default(DbSet<T>))
                return;

            dbSet.Remove(item);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            DbSet<T> dbSet = _context.Set<T>();

            if (dbSet == default(DbSet<T>))
                return default(List<T>);

            return dbSet.ToList();
        }

        public T GetById(int id)
        {
            DbSet<T> dbSet = _context.Set<T>();
            if (dbSet == default(DbSet<T>))
                return default(T);

            T entity = dbSet.FirstOrDefault(z => z.Id.Equals(id));
            return entity;
        }

        public void Update(T Item)
        {
            DbSet<T> dbSet = _context.Set<T>();
            if (dbSet == default(DbSet<T>))
                return;

            dbSet.Update(Item);
            _context.SaveChanges();
        }
        
        
    }
}
