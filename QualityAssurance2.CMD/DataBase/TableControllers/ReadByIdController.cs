using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.Data.DataBase.SqlServer;
using QualityAssurance2.Data.Repositories.Implementations;

namespace QualityAssurance2.CMD.DataBaseControllers.TableControllers
{
    public static class ReadByIdController
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
