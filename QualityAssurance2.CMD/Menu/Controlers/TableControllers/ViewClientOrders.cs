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

            if (client.Orders == null) return;

            List<Order> orders = client.Orders.ToList();

            ViewOrders(orders);
        }
        public static void ViewOrders(List<Order> orders)
        {
            if(orders ==  null) return;

            ViewTables<Order>.OrdersTable(orders);

            //foreach (Order order in orders)
            //{
            //    List<Order> orderss = new List<Order>(){ order };
            //    ViewTables<Order>.OrdersTable(orderss);
            //}
        }
    }
}
