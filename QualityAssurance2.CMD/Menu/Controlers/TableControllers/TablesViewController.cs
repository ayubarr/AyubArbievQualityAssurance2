using AyubArbievQualityAssurance2.Data.Models.Common;
using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.Data.DataBase.SqlServer;
using QualityAssurance2.Data.Repositories.Implementations;

namespace QualityAssurance2.CMD.Menu.Controlers.Tables
{
    public static class TablesViewController<T> where T : BaseEntity
    {
        public static List<T> GetTable()
        {
            using (AppDbContext dataBase = new AppDbContext())
            {
                Repository<T> repository = new Repository<T>(dataBase);
                List<T> list = repository.GetAll();
                return list;
            }
        }

        public static void ViewTable(List<T> list)
        {
            if (typeof(T) == typeof(Client))
            {
                List<Client> clients = list.Cast<Client>().ToList();
                ClientsTable(clients);
            }
            if (typeof(T) == typeof(Order))
            {
                List<Order> orders = list.Cast<Order>().ToList();
                OrdersTable(orders);
            }
        }
        private static void ClientsTable(List<Client> clients)
        {
            Console.WriteLine("Clients Table:\n" +
                "ID|FirstName|LastName|PhoneNum|OrderAmount|DateAdd|");
            foreach (var client in clients)
                Console.WriteLine($" {client.Id}|" +
                    $"{client.FirstName}|" +
                    $"{client.LastName}|" +
                    $"{client.PhoneNum}|" +
                    $"{client.OrderAmount}|" +
                    $"{client.DateAdd}|\n");
        }
        private static void OrdersTable(List<Order> orders)
        {
            Console.WriteLine("Orders Table:\n" +
               "ID| OrderPrice |OrderDate |CloseDate |Client |ClientId|");
            foreach (var order in orders)
                Console.WriteLine($" {order.Id}|" +
                    $"{order.OrderPrice}|" +
                    $"{order.OrderDate}|" +
                    $"{order.CloseDate}|" +
                    $"{order.Client}|" +
                    $"{order.ClientId}|\n" +
                    $"Description: {order.Description}\n");
        }
    }
}
