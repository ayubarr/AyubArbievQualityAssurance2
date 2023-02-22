using AyubArbievQualityAssurance2.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyubArbievQualityAssurance2.Data.Models.Entities
{
    public class Order : BaseEntity
    {
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Description { get; set; }
        public float OrderPrice { get; set; }
        public DateTime CloseDate { get; set; }

    }
}
