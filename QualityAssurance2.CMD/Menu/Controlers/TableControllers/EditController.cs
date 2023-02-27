using AyubArbievQualityAssurance2.Data.Models.Common;
using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.Menu.Controlers.ConsoleControllers;
using QualityAssurance2.CMD.Menu.Controlers.MenuControllers;
using QualityAssurance2.CMD.Menu.Controlers.Tables;
using QualityAssurance2.Data.DataBase.SqlServer;
using QualityAssurance2.Data.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QualityAssurance2.CMD.Menu.Controlers.TableControllers
{
    public static class EditController<T> where T : BaseEntity
    {
        public static void UpdateEntityInDb(T updatedEntity)
        {
            using (AppDbContext dataBase = new AppDbContext())
            {
                Repository<T> repository = new Repository<T>(dataBase);
                if (typeof(T) == typeof(Client))
                {
                    Client client = (Client)(object)updatedEntity;
                    repository.Update((T)(object)client);
                }
                if (typeof(T) == typeof(Order))
                {
                    Order order = (Order)(object)updatedEntity;
                    repository.Update((T)(object)order);
                }
            }
        }

        public static Client EditClientInConsole(Client client)
        {
            Console.WriteLine("Let's Edit a Client");
            string clientFirstName = ConsoleReader<string>.Read("client new FirstName");
            string clientLastName = ConsoleReader<string>.Read("client new LastName");
            string phoneNum = ConsoleReader<string>.Read("client new Phone Number");
            bool isPhoneNumberCorrect = true;
            while (isPhoneNumberCorrect)
            {
                string phoneNumber = ConsoleReader<string>.Read($"client Phone Number in format " +
                    $"{ConsoleConstants.PhoneNumberPattern}");
                if (Regex.IsMatch(phoneNumber, @"^\+996\(\d{3}\)\d{2}-\d{2}-\d{2}$"))
                {
                    isPhoneNumberCorrect = false;
                    phoneNum = phoneNumber;
                }
                else
                    Console.WriteLine($"An error while getting value received." +
                   $" Please enter client Phone Number in format {ConsoleConstants.PhoneNumberPattern} again");
            }
            client.FirstName = clientFirstName;
            client.LastName = clientLastName;
            client.PhoneNum = phoneNum;
            client.DateAdd = DateTime.Now;
                        
            return client;
        }
        public static Order EditOrderInConsole(Order order)
        {
            Console.WriteLine("Let's Edit a order!");
            float orderPrice = ConsoleReader<float>.Read("new order price");
            DateTime dateClose = ConsoleReader<DateTime>.Read($"new close date in format {ConsoleConstants.DateTimePattern}");
            List<Client> allClients = ViewTables<Client>.GetFullTable();
            ViewTables<Client>.ViewTable(allClients);
            int clientId = ConsoleReader<int>.Read($"new сlient Id. ");
            string description = ConsoleReader<string>.Read("description of product");

            order.OrderPrice = orderPrice;
            order.OrderDate = DateTime.Now;
            order.CloseDate = dateClose;          
            order.ClientId = clientId;
            order.Description = description;   

            return order;
        }

        public static Order UpdateClientWithAddedOrder(Order order)
        {
            Client updateClient = ReadByIdController.GetClientById(order.ClientId);
             if (updateClient == default(T))
             {
                BackToMainMenu(order.ClientId);
             }

            updateClient.OrderAmount++;
            EditController<Client>.UpdateEntityInDb(updateClient);
            return order;

        }
        public static Order UpdateClientWithDeletedOrder(Order order)
        {
            Client updateClient = ReadByIdController.GetClientById(order.ClientId);
            if (updateClient == default(T))
            {
                BackToMainMenu(order.ClientId);
            }

            updateClient.OrderAmount--;
            EditController<Client>.UpdateEntityInDb(updateClient);
            return order;
        }
        private static void BackToMainMenu(int entityId)
        {
            Console.WriteLine($"Entity with ID {entityId} not found");
            Console.ReadKey();
            Console.Clear();
            MainMenu.MainMenuButtons();   
        }
    }
}
