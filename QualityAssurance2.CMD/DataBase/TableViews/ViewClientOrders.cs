using AyubArbievQualityAssurance2.Data.Models.Entities;

namespace QualityAssurance2.CMD.DataBaseControllers.TableViews
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
