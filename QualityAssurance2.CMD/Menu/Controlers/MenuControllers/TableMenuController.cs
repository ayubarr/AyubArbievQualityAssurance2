using AyubArbievQualityAssurance2.Data.Models.Common;
using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.Menu.Controlers.TableControllers;

namespace QualityAssurance2.CMD.Menu.Controlers.MenuControllers
{
    public static class TableMenuController<T> where T : BaseEntity
    {

        public static void TableMenuButtons()
        {

            ViewTableMenuInfo();
            string choice = ClickCheck();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    if (typeof(T) == typeof(Client))
                    {
                        Client client = AddController<Client>.AddEntity();
                        AddController<Client>.AddEntityToDb(client);
                    }

                    if (typeof(T) == typeof(Order))
                    {
                       Order order = AddController<Order>.AddEntity();
                       AddController<Order>.AddEntityToDb(order);
                    }

                    break;

                case "2":
                    Console.Clear();
                    break;

                case "3":
                    Console.Clear();
                    break;

                case "4":
                    Console.Clear();
                    break;

                case "Backspace":
                    Console.Clear();
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
