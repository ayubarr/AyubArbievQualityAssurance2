using AyubArbievQualityAssurance2.Data.Models.Common;
using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.Menu.Controlers.Tables;

namespace QualityAssurance2.CMD.Menu.Controlers.MenuControllers
{
    public class SuccesMenuController<T> where T : BaseEntity
    {
        public static void SuccesMenuButtons()
        {

            ViewMainMenuInfo();
            string choice = ClickCheck();
            switch (choice)
            {
                case "Y":
                    break;

                case "N":
                    Console.Clear();
                    List<Client> clients = ViewTables<Client>.GetFullTable();
                    ViewTables<Client>.ViewTable(clients);
                    TableMenuController<T>.TableMenuButtons();
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
                    "Y",
                    "N",
                    "Escape"
            };
            string choiceButtom = ButtonController.Button(keys);
            return choiceButtom;
        }
        private static void ViewMainMenuInfo()
        {
            Console.WriteLine("WARNING!!\n" +
                "If you delete a client, all his orders will also be deleted\n" +
                "[Y] - Yes, delete client\n" +
               "[N] - No, cancel deletion \n" +
               "[Esc] - Exit");
        }
    }
}
