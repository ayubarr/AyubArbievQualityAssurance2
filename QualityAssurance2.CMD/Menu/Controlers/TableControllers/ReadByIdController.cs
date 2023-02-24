using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.Data.DataBase.SqlServer;
using QualityAssurance2.Data.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityAssurance2.CMD.Menu.Controlers.TableControllers
{
    public  static class ReadByIdController
    {
        public static Client GetClientById(int id)
        {
            using (AppDbContext dataBase = new AppDbContext())
            {
                Repository<Client> repository = new Repository<Client>(dataBase);
                Client client = repository.GetById(id);
                return client;
            }

        }
        public static Order GetOrderById(int id)
        {
            using (AppDbContext dataBase = new AppDbContext())
            {
                Repository<Order> repository = new Repository<Order>(dataBase);
                Order order = repository.GetById(id);
                return order;
            }
        }
    }
}
