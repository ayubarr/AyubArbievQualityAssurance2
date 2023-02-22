using AyubArbievQualityAssurance2.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyubArbievQualityAssurance2.Data.Models.Entities
{
    public class Client : Person
    {
        public string PhoneNum { get; set; }
        public int OrderAmount { get; set; }
        public DateTime DateAdd { get; set; } 
    }
}
