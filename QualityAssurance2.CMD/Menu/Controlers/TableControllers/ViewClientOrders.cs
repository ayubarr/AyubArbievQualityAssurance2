using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.Menu.Controlers.Tables;

namespace QualityAssurance2.CMD.Menu.Controlers.TableControllers
{
    public class ViewClientOrders
    {
        public static void ViewClient(Client client)
        {
            List<Client> clients = new List<Client>() { client };
            ViewTables<Client>.ClientsTable(clients);
            ViewOrders(client.Orders);
        }
        public static void ViewOrders(ICollection<Order> orders)
        {
            foreach (Order order in orders)
            {
                List<Order> orderss = new List<Order>(){ order };
                ViewTables<Order>.OrdersTable(orderss);
            }
        }
    }
}
