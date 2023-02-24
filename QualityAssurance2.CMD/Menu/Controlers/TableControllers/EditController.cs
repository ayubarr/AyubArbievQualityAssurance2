using AyubArbievQualityAssurance2.Data.Models.Common;
using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.Menu.Controlers.ConsoleControllers;
using QualityAssurance2.CMD.Menu.Controlers.Tables;
using QualityAssurance2.Data.DataBase.SqlServer;
using QualityAssurance2.Data.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityAssurance2.CMD.Menu.Controlers.TableControllers
{
    public static class EditController<T> where T : BaseEntity
    {
        public static void UpdateEntityInDb(T updatedEntity)
        {
            using (AppDbContext dataBase = new AppDbContext())
            {
                Repository<T> repository = new Repository<T>(dataBase);
                if (typeof(T) == typeof(Client))
                {
                    Client client = (Client)(object)updatedEntity;
                    repository.Update((T)(object)client);
                }
                if (typeof(T) == typeof(Order))
                {
                    Order order = (Order)(object)updatedEntity;
                    repository.Update((T)(object)order);
                }
            }
        }
        public static T EditEntityInConsole(T entity)
        {
            if (typeof(T) == typeof(Client))
                return (T)(object)EditClientInConsole((Client)(object)entity);

            if (typeof(T) == typeof(Order))
                return (T)(object)EditOrderInConsole((Order)(object)entity);

            return default(T);
        }

        public static Client EditClientInConsole(Client client)
        {
            Console.WriteLine("Let's Edit a Client");
            string clientFirstName = ConsoleReader<string>.Read("client FirstName");
            string clientLastName = ConsoleReader<string>.Read("client LastName");
            string phoneNum = ConsoleReader<string>.Read("client Phone Number");
            DateTime dateAdd = ConsoleReader<DateTime>.Read($"add date in format {ConsoleConstants.DateTimePattern}");

            client.FirstName = clientFirstName;
            client.LastName = clientLastName;
            client.PhoneNum = phoneNum;
            client.DateAdd = dateAdd;
                        
            return client;
        }
        public static Order EditOrderInConsole(Order order)
        {
            Console.WriteLine("Let's Edit a order!");
            List<Client> allClients = ViewTables<Client>.GetTable();
            float orderPrice = ConsoleReader<float>.Read("order price");
            DateTime dateAdd = ConsoleReader<DateTime>.Read($"add date in format {ConsoleConstants.DateTimePattern}");
            DateTime dateClose = ConsoleReader<DateTime>.Read($"close date in format {ConsoleConstants.DateTimePattern}");
            int clientId = ConsoleReader<int>.Read($"сlient Id. total clients  {allClients.Count}");
            Client client = ReadByIdController.GetClientById(clientId);
            if (client == default(T))
            {
                Console.WriteLine($"Client with ID {clientId} not found");
                return null;
            }
            string description = ConsoleReader<string>.Read("description of product");

            order.OrderPrice = orderPrice;
            order.OrderDate = dateAdd;
            order.CloseDate = dateClose;
            order.Client = client;
            order.ClientId = clientId;
            order.Description = description;   

            return order;
        }

        
    }
}
