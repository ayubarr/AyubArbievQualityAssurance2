using AyubArbievQualityAssurance2.Data.Models.Common;
using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.Data.DataBase.SqlServer;
using QualityAssurance2.Data.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityAssurance2.CMD.Menu.Controlers
{
    public static class TablesController<T> where T : BaseEntity
    {
        public static List<T> GetTable()
        {
            using(AppDbContext dataBase = new AppDbContext())
            {
                Repository<T> repository = new Repository<T>(dataBase);
                List<T> list = repository.GetAll();
                return list;    
            }
        }

        public static void ViewTable(List<T> list) {
            Console.WriteLine("Orders Table: ");
            if(typeof(Client) == typeof(T))
            {
              
            }
            if(typeof(Order) == typeof(T) )
            {

            }
            
        }

    }
}
