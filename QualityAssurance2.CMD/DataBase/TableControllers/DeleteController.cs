using AyubArbievQualityAssurance2.Data.Models.Common;
using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.DataBaseControllers.TableViews;
using QualityAssurance2.CMD.Menu.Controlers.ConsoleControllers;
using QualityAssurance2.CMD.Menu.Models;
using QualityAssurance2.Data.DataBase.SqlServer;
using QualityAssurance2.Data.Repositories.Implementations;

namespace QualityAssurance2.CMD.DataBaseControllers.TableControllers
{
    public static class DeleteController<T> where T : BaseEntity
    {
        public static void DeleteEntityInDb(T entity)
        {
            using (AppDbContext dataBase = new AppDbContext())
            {
                Repository<T> repository = new Repository<T>(dataBase);
                if (typeof(T) == typeof(Client))
                {
                    Client client = (Client)(object)entity;
                    repository.Delete((T)(object)client);
                }
                if (typeof(T) == typeof(Order))
                {
                    Order order = (Order)(object)entity;
                    repository.Delete((T)(object)order);
                }
            }
        }

        public static T GetEntityInDb()
        {
            if (typeof(T) == typeof(Client))
            {
                List<Client> clients = ViewTables<Client>.GetFullTable();
                ViewTables<Client>.ViewTable(clients);
                return (T)(object)GetDeletedClientById();
            }
            if (typeof(T) == typeof(Order))
            {
                List<Order> orders = ViewTables<Order>.GetFullTable();
                ViewTables<Order>.ViewTable(orders);
                return (T)(object)GetDeletedOrderById();
            }
            return default;
        }
        private static Client GetDeletedClientById()
        {
            int clientId = ConsoleReader<int>.Read("client Id");
            Client client = ReadByIdController.GetClientById(clientId);
            if (client == default(T))
            {
                BackToMainMenu(clientId);
                return default;
            }
            return client;
        }
        private static Order GetDeletedOrderById()
        {
            int orderId = ConsoleReader<int>.Read("order Id");
            Order order = ReadByIdController.GetOrderById(orderId);
            if (order == default(T))
            {
                BackToMainMenu(orderId);
                return default;
            }
            return order;
        }
        public static void BackToMainMenu(int entity)
        {
            Console.WriteLine($"Entity with ID {entity} not found");
            Console.ReadKey();
            Console.Clear();
            MainMenu.MainMenuButtons();
        }

    }
}
