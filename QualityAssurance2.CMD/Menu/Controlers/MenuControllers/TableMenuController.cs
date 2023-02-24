using AyubArbievQualityAssurance2.Data.Models.Common;
using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.Menu.Controlers.TableControllers;
using QualityAssurance2.CMD.Menu.Controlers.Tables;

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
                        Client client = AddController<Client>.GetEntityFromConsole();
                        AddController<Client>.AddEntityToDb(client);
                    }

                    if (typeof(T) == typeof(Order))
                    {
                        Order order = AddController<Order>.GetEntityFromConsole();
                        AddController<Order>.AddEntityToDb(order);
                    }

                    break;

                case "2":
                    Console.Clear();
                    if (typeof(T) == typeof(Client))
                    {
                        Client oldClient = DeleteController<Client>.GetEntityInDb();
                        Client newClient = EditController<Client>.EditEntityInConsole(oldClient);
                        EditController<Client>.UpdateEntityInDb(newClient);


                    }
                    if (typeof(T) == typeof(Order))
                    {
                        Order oldOrder = DeleteController<Order>.GetEntityInDb();
                        Order newOrder = EditController<Order>.EditEntityInConsole(oldOrder);
                        EditController<Order>.UpdateEntityInDb(newOrder);
                    }


                    break;

                case "3":
                    Console.Clear();
                    if (typeof(T) == typeof(Client))
                    {
                        SuccesMenuController<Client>.SuccesMenuButtons();
                        Client client = DeleteController<Client>.GetEntityInDb();
                        DeleteController<Client>.DeleteEntityInDb(client);
                    }
                    if (typeof(T) == typeof(Order))
                    {
                        Order order = DeleteController<Order>.GetEntityInDb();
                        DeleteController<Order>.DeleteEntityInDb(order);
                    }
                    break;

                case "4":
                    Console.Clear();
                    Client showedClient = DeleteController<Client>.GetEntityInDb();
                    ViewClientOrders.ViewClient(showedClient);
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
