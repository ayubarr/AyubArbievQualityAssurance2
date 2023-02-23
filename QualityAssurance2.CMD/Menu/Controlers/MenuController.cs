using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.Data.Repositories.Implementations;
using QualityAssurance2.Data.Repositories.Interfaces;

namespace QualityAssurance2.CMD.Menu.Controlers
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
                    List<Client> clients = TablesController<Client>.GetTable();
                    TablesController<Client>.ViewTable(clients);
                    break;

                case "2":
                    Console.Clear();
                    List<Order> orders = TablesController<Order>.GetTable();
                    TablesController<Order>.ViewTable(orders);
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
