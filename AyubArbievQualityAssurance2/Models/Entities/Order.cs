using AyubArbievQualityAssurance2.Data.Models.Common;

namespace AyubArbievQualityAssurance2.Data.Models.Entities
{
    public class Order : BaseEntity
    {

        public int ClientId { get; set; }
        public Client? Client { get; set; } = new Client { };
        public DateTime OrderDate { get; set; }
        public string Description { get; set; }
        public float OrderPrice { get; set; }
        public DateTime CloseDate { get; set; }


    }
}
