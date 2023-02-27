using AyubArbievQualityAssurance2.Data.Models.Common;
using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.DataBaseControllers.TableControllers;
using QualityAssurance2.CMD.DataBaseControllers.TableViews;
using QualityAssurance2.CMD.Menu.Controlers.MenuControllers;
using QualityAssurance2.CMD.Menu.Controlers.TableMenuControllers;

namespace QualityAssurance2.CMD.Menu.Models
{
    public static class TableMenu<T> where T : BaseEntity
    {

        public static void TableMenuButtons()
        {

            ViewTableMenuInfo();
            string choice = ClickCheck();
            switch (choice)
            {
                case "1":
                    TableMenuButtonsController<T>.AddButtonReaction();
                    break;

                case "2":
                    TableMenuButtonsController<T>.EditMenuReaction();
                    break;

                case "3":
                    TableMenuButtonsController<T>.DeleteButtonReaction();
                    break;

                case "4":
                    TableMenuButtonsController<T>.ShowClientsButtonReaction();
                    break;

                case "Backspace":
                    Console.Clear();
                    MainMenu.MainMenuButtons();
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
                    "3",
                    "4",
                    "Escape",
                    "Backspace",
            };
            string choiceButtom = ButtonController.Button(keys);
            return choiceButtom;
        }
        private static void ViewTableMenuInfo()
        {
            Console.WriteLine(
                "[1] - Add\n" +
               "[2] - Edit \n" +
               "[3] - Delete\n" +
               "[4] - Show client’s orders\n" +
               "[Back] - Return\n" +
               "[Esc] - Exit\n"
               );
        }
    }
}
