using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACDDS.TreasureHunter.Web.Models
{
    public class CharactersResponse
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Luck { get; set; }
        public int Wealth { get; set; }
    }
}
