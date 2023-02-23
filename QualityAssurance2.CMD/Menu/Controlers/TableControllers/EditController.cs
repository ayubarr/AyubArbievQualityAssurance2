using AyubArbievQualityAssurance2.Data.Models.Common;
using AyubArbievQualityAssurance2.Data.Models.Entities;
using QualityAssurance2.CMD.Menu.Controlers.ConsoleControllers;
using QualityAssurance2.CMD.Menu.Controlers.Tables;

namespace QualityAssurance2.CMD.Menu.Controlers.TableControllers
{
    public static class EditController<T> where T : BaseEntity
    {


        public static T SetUpdateEntity()
        {
            if (typeof(T) == typeof(Client))
            {
                List<Client> clients = TablesViewController<Client>.GetTable();
                TablesViewController<Client>.ViewTable(clients);
                return (T)(object)GetEntityById();
            }
            if(typeof(T) == typeof(Order))
            {
                List<Order> orders = TablesViewController<Order>.GetTable();
                TablesViewController<Order>.ViewTable(orders);
                return (T)(object)GetEntityById();
            }
            return default(T);
        }

        private static T GetEntityById()
        {
            int entityId = ConsoleReader<int>.Read($"Id");
            T entity = (T)(object)AddController<T>.GetClientById(entityId);
            if (entity == default(T))
            {
                Console.WriteLine($"Client with ID {entityId} not found");
                return null;
            }
            return entity;
        }
    }
}
