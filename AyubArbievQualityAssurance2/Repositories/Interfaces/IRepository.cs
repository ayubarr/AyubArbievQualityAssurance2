using AyubArbievQualityAssurance2.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityAssurance2.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public T Add(T item);        // C - Create
        public List<T> GetAll();     // R - ReadAll
        public T GetById(int id);    // R - ReadOne
        public void Update(T Item);  // U - Update
        public void Delete(T item);  // D - Delete
    }
}
