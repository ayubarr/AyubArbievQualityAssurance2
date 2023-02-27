using AyubArbievQualityAssurance2.Data.Models.Common;
using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.DataBaseControllers.TableControllers;
using QualityAssurance2.CMD.DataBaseControllers.TableViews;
using QualityAssurance2.CMD.Menu.Models;

namespace QualityAssurance2.CMD.Menu.Controlers.TableMenuControllers
{
    public static class TableMenuButtonsController<T> where T : BaseEntity
    {
        public static void AddButtonReaction()
        {
            Console.Clear();
            if (typeof(T) == typeof(Client))
            {
                Client client = AddController<Client>.GetEntityFromConsole();
                if (client != null) AddController<Client>.AddEntityToDb(client);
                else Back();
            }

            if (typeof(T) == typeof(Order))
            {
                Order order = AddController<Order>.GetEntityFromConsole();
                order = EditController<Order>.UpdateClientWithAddedOrder(order);
                if (order != null) AddController<Order>.AddEntityToDb(order);
                else Back();
            }
            BackToMainMenu();
        }

        public static void EditMenuReaction()
        {
            Console.Clear();
            if (typeof(T) == typeof(Client))
            {
                Client oldClient = DeleteController<Client>.GetEntityInDb();
                if (oldClient != null)
                {
                    Client newClient = EditController<Client>.EditClientInConsole(oldClient);
                    EditController<Client>.UpdateEntityInDb(newClient);
                }
                else Back();
            }
            if (typeof(T) == typeof(Order))
            {
                Order oldOrder = DeleteController<Order>.GetEntityInDb();
                if (oldOrder != null)
                {
                    Order newOrder = EditController<Order>.EditOrderInConsole(oldOrder);
                    newOrder = EditController<Order>.UpdateClientWithAddedOrder(newOrder);
                    if (newOrder != null) EditController<Order>.UpdateEntityInDb(newOrder);
                }
                else Back();
            }
            BackToMainMenu();
        }

        public static void DeleteButtonReaction()
        {
            Console.Clear();
            if (typeof(T) == typeof(Client))
            {
                SuccesMenuController<Client>.SuccesMenuButtons();
                Client client = DeleteController<Client>.GetEntityInDb();
                if (client != null) DeleteController<Client>.DeleteEntityInDb(client);
                else Back();
            }
            if (typeof(T) == typeof(Order))
            {
                Order order = DeleteController<Order>.GetEntityInDb();
                order = EditController<Order>.UpdateClientWithDeletedOrder(order);
                if (order != null) DeleteController<Order>.DeleteEntityInDb(order);
                else Back();
            }

            MainMenu.MainMenuButtons();
        }
        public static void ShowClientsButtonReaction()
        {
            Console.Clear();
            Client showedClient = DeleteController<Client>.GetEntityInDb();
            if (showedClient != null) ViewClientOrders.ViewClient(showedClient);
            else Back();

            Console.ReadKey();
            BackToMainMenu();
        }


        private static void Back()
        {
            Console.Clear();
            List<Client> clients = ViewTables<Client>.GetFullTable();
            ViewTables<Client>.ViewTable(clients);
            TableMenu<T>.TableMenuButtons();
        }
        private static void BackToMainMenu()
        {
            Console.Clear();
            MainMenu.MainMenuButtons();
        }

    }
}
