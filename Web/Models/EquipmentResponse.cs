using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class EquipmentResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int HpModifier { get; set; }
        public int LuckModifier { get; set; }
        public int Value { get; set; }
    }
}
