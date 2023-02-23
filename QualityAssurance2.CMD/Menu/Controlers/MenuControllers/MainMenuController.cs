using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.Menu.Controlers.Tables;

namespace QualityAssurance2.CMD.Menu.Controlers.MenuControllers
{
    public static class MenuController
    {
        public static void MainMenuButtons()
        {

            ViewMainMenuInfo();
            string choice = ClickCheck();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    List<Client> clients = TablesViewController<Client>.GetTable();
                    TablesViewController<Client>.ViewTable(clients);
                    break;

                case "2":
                    Console.Clear();
                    List<Order> orders = TablesViewController<Order>.GetTable();
                    TablesViewController<Order>.ViewTable(orders);
                    break;

                case "Escape":
                    Environment.Exit(0);
                    break;
            }
        }
        private static string ClickCheck()
        {

            string[] keys = new string[]
            {
                    "1",
                    "2",
                    "Escape"
            };
            string choiceButtom = ButtonController.Button(keys);
            return choiceButtom;
        }
        private static void ViewMainMenuInfo()
        {
            Console.WriteLine("[1] - Clients Table\n" +
               "[2] - Orders Table \n" +
               "[Esc] - Exit");
        }
    }
}
