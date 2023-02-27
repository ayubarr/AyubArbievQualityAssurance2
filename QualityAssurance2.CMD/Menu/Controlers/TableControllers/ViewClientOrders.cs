using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.Menu.Controlers.Tables;

namespace QualityAssurance2.CMD.Menu.Controlers.TableControllers
{
    public class ViewClientOrders
    {
        public static void ViewClient(Client client)
        {
            Console.Clear();
            List<Client> clients = new List<Client>() { client };
            ViewTables<Client>.ClientsTable(clients);
            List<Order> allorders = ViewTables<Order>.GetFullTable();
            List<Order> Correctorders = allorders.Where(z => client.Id == z.ClientId).ToList();
            ViewOrders(Correctorders);
        }
        public static void ViewOrders(List<Order> orders)
        {
            if (orders == null) return;

            ViewTables<Order>.OrdersTable(orders);

        }
    }
}
