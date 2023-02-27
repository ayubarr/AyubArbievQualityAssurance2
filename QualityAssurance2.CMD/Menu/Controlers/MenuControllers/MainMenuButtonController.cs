using AyubArbievQualityAssurance2.Data.Models.Common;
using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.Menu.Controlers.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(typeof(T) == typeof(Order))
            {
                List<Order> orders = ViewTables<Order>.GetFullTable();
                ViewTables<Order>.ViewTable(orders);
                TableMenuController<Order>.TableMenuButtons();
            }
        }
    }
}
