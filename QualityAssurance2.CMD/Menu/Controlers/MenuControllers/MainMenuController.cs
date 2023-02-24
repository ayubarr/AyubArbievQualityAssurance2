using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.Menu.Controlers.Tables;

namespace QualityAssurance2.CMD.Menu.Controlers.MenuControllers
{
    public static class MainMenuController
    {
        public static void MainMenuButtons()
        {

            ViewMainMenuInfo();
            string choice = ClickCheck();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    List<Client> clients = ViewTables<Client>.GetTable();
                    ViewTables<Client>.ViewTable(clients);
                    TableMenuController<Client>.TableMenuButtons();
                    break;

                case "2":
                    Console.Clear();
                    List<Order> orders = ViewTables<Order>.GetTable();
                    ViewTables<Order>.ViewTable(orders);
                    TableMenuController<Order>.TableMenuButtons();
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
