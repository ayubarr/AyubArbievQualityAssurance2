using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.Menu.Controlers.MenuControllers;

namespace QualityAssurance2.CMD.Menu.Models
{
    public static class MainMenu
    {
        public static void MainMenuButtons()
        {
            ViewMainMenuInfo();
            string choice = ClickCheck();
            switch (choice)
            {
                case "1":
                    MainMenuButtonController<Client>.MainMenuButtonReaction();
                    break;

                case "2":
                    MainMenuButtonController<Order>.MainMenuButtonReaction();
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
