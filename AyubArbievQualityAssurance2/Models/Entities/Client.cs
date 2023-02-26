using AyubArbievQualityAssurance2.Data.Models.Common;

namespace AyubArbievQualityAssurance2.Data.Models.Entities
{
    public class Client : Person
    {
        public string PhoneNum { get; set; }
        public int OrderAmount { get; set; }
        public DateTime DateAdd { get; set; }
        public List<Order> Orders = new List<Order>();
    }
}
