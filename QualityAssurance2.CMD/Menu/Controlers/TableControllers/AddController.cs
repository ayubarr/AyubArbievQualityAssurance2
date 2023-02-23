using AyubArbievQualityAssurance2.Data.Models.Common;
using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.Menu.Controlers.ConsoleControllers;
using QualityAssurance2.CMD.Menu.Controlers.Tables;
using QualityAssurance2.Data.DataBase.SqlServer;
using QualityAssurance2.Data.Repositories.Implementations;


namespace QualityAssurance2.CMD.Menu.Controlers.TableControllers
{
    public static class AddController<T> where T : BaseEntity
    {
        public static T CheckEntityType()
        {
            if (typeof(T) == typeof(Client))
                return (T)(object)GetClientFromConsole();
            
            if (typeof(T) == typeof(Order))
                return (T)(object)GetOrderFromConsole();

            return default(T);
        }

        private static Client GetClientFromConsole()
        {
            Console.WriteLine("Let's Add a Client!");
            string clientFirstName = ConsoleReader<string>.Read("client FirstName");
            string clientLastName = ConsoleReader<string>.Read("client LastName");
            string phoneNum = ConsoleReader<string>.Read("client Phone Number");
            
            DateTime dateAdd = ConsoleReader<DateTime>.Read($"add date in format {ConsoleConstants.DatePattern}");

            Client client = new Client()
            {
                FirstName = clientFirstName,
                LastName = clientLastName,
                PhoneNum = phoneNum,
                DateAdd = dateAdd,
                OrderAmount = 0,
            };
            return client;
        }
        private static Order GetOrderFromConsole()
        {
            Console.WriteLine("Orders Table:\n" +
              "ID|    OrderPrice   |   OrderDate   |   CloseDate   |   Client   |   ClientId   |");

            List<Client> allClients = TablesViewController<Client>.GetTable();
            Console.WriteLine("Let's create a order!");
            float orderPrice = ConsoleReader<float>.Read("order price");
            DateTime dateAdd = ConsoleReader<DateTime>.Read($"add date in format {ConsoleConstants.DatePattern}");
            DateTime dateClose = ConsoleReader<DateTime>.Read($"close date in format {ConsoleConstants.DatePattern}");
            int clientId = ConsoleReader<int>.Read($"сlient Id. total clients  {allClients.Count}");
            Client client = GetClientById(clientId);
            string description = ConsoleReader<string>.Read("description of product");


            Order order = new Order()
            {
                OrderPrice = orderPrice,
                OrderDate = dateAdd,
                CloseDate = dateClose,
                Client = client,
                ClientId = clientId,
                Description = description,
                
            };
            return order;
        }
        private static Client GetClientById(int id)
        {
            using (AppDbContext dataBase = new AppDbContext())
            {
                Repository<Client> repository = new Repository<Client>(dataBase);
                Client entity = repository.GetById(id);
                return entity;
            }
        }

    }
}
