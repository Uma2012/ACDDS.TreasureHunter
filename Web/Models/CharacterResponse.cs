using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACDDS.TreasureHunter.Web.Models
{
    public class CharacterResponse
    {
        [Display(Name="Character")]
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Luck { get; set; }
        public int Wealth { get; set; }

        [Display(Name = "Equipment Owned")]
        public IList<EquipmentResponse> Equipment { get; set; }
        
    }
}
