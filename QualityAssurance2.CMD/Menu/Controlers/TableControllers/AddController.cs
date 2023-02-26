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
        public static void AddEntityToDb(T entity)
        {
            using (AppDbContext dataBase = new AppDbContext())
            {
                Repository<T> repository = new Repository<T>(dataBase);
                if (typeof(T) == typeof(Client))
                {
                    Client client = (Client)(object)entity;
                    repository.Add((T)(object)client);
                }
                if (typeof(T) == typeof(Order))
                {
                    Order order = (Order)(object)entity;
                    repository.Add((T)(object)order);
                }
            }
        }
        public static T GetEntityFromConsole()
        {
            if (typeof(T) == typeof(Client))
                return (T)(object)GetClientFromConsole();
            
            if (typeof(T) == typeof(Order))
                return (T)(object)GetOrderFromConsole();

            return default(T);
        }

        public static Client GetClientFromConsole()
        {
            Console.WriteLine("Let's Add a Client!");
            string clientFirstName = ConsoleReader<string>.Read("client FirstName");
            string clientLastName = ConsoleReader<string>.Read("client LastName");
            string phoneNum = ConsoleReader<string>.Read("client Phone Number");           
            //DateTime dateAdd = ConsoleReader<DateTime>.Read($"add date in format {ConsoleConstants.DateTimePattern}");

            Client client = new Client()
            {
                FirstName = clientFirstName,
                LastName = clientLastName,
                PhoneNum = phoneNum,
                DateAdd = DateTime.Now,
                OrderAmount = 0,
            };
            return client;
        }
        public static Order GetOrderFromConsole()
        {            
            Console.WriteLine("Let's create a order!");
            List<Client> allClients = ViewTables<Client>.GetTable();
            float orderPrice = ConsoleReader<float>.Read("order price");
            //DateTime dateAdd = ConsoleReader<DateTime>.Read($"add date in format {ConsoleConstants.DateTimePattern}");
            DateTime dateClose = ConsoleReader<DateTime>.Read($"close date in format {ConsoleConstants.DateTimePattern}");
            int clientId = ConsoleReader<int>.Read($"сlient Id. total clients  {allClients.Count}");
            Client client = ReadByIdController.GetClientById(clientId);
            if(client == default(T))
            {
                Console.WriteLine($"Client with ID {clientId} not found");
                return null;
            }
            string description = ConsoleReader<string>.Read("description of product");
           
            client.OrderAmount++;

            Order order = new Order()
            {
                OrderPrice = orderPrice,
                OrderDate = DateTime.Now,
                CloseDate = dateClose,
                ClientId = clientId,
                Description = description,
                Client = client,
            };

    
            EditController<Client>.UpdateEntityInDb(client);

            return order;
        }
    }
}
