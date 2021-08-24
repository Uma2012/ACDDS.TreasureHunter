using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACDDS.TreasureHunter.Web.Models
{
    public class PurchaseResponse
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Luck { get; set; }
        public int Wealth { get; set; }        
        public IList<EquipmentResponse> Equipment { get; set; }
        public string StatusResponse { get; set; }
        public string ErrorInsufficientValue { get; set; }
    }
}
