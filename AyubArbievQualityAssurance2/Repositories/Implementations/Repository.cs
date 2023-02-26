using AyubArbievQualityAssurance2.Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using QualityAssurance2.Data.DataBase.SqlServer;
using QualityAssurance2.Data.Repositories.Interfaces;

namespace QualityAssurance2.Data.Repositories.Implementations
{
    public class Repository<T> : IExist, IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _contextDb;

        public Repository(AppDbContext context)
        {
            _contextDb = context;
        }

        public bool DataBaseExist()
        {
            DbSet<T> TestSet = _contextDb.Set<T>();
            if (TestSet == default(DbSet<T>))
                return true;

            return false;
        }

        public T Add(T item)
        {
            if (DataBaseExist()) return default(T);
            T result = _contextDb.Set<T>().Add(item).Entity;
            _contextDb.SaveChanges();
            return result;
        }

        public void Delete(T item)
        {
            if (DataBaseExist()) return;
            _contextDb.Set<T>().Remove(item);
            _contextDb.SaveChanges();
        }

        public List<T> GetAll()
        {
            if (DataBaseExist()) return default(List<T>);
            return _contextDb.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            if (DataBaseExist()) return default(T);
            T entity = _contextDb.Set<T>().FirstOrDefault(z => z.Id.Equals(id));
            return entity;
        }

        public void Update(T Item)
        {
            if (DataBaseExist()) return;
            _contextDb.Set<T>().Update(Item);
            _contextDb.SaveChanges();
        }


    }
}
