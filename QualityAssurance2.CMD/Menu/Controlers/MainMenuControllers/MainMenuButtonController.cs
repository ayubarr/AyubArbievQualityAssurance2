using AyubArbievQualityAssurance2.Data.Models.Common;
using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.DataBaseControllers.TableViews;
using QualityAssurance2.CMD.Menu.Controlers.TableMenuControllers;

namespace QualityAssurance2.CMD.Menu.Controlers.MenuControllers
{
    public static class MainMenuButtonController<T> where T : BaseEntity
    {
        public static void MainMenuButtonReaction()
        {
            Console.Clear();
            if (typeof(T) == typeof(Client))
            {
                List<Client> clients = ViewTables<Client>.GetFullTable();
                ViewTables<Client>.ViewTable(clients);
                TableMenuController<Client>.TableMenuButtons();
            }
            if (typeof(T) == typeof(Order))
            {
                List<Order> orders = ViewTables<Order>.GetFullTable();
                ViewTables<Order>.ViewTable(orders);
                TableMenuController<Order>.TableMenuButtons();
            }
        }
    }
}
