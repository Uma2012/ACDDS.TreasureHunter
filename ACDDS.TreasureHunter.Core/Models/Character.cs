using System.Collections.Generic;

namespace ACDDS.TreasureHunter.Core.Models
{
    public class Character
    {

        //public Character()
        //{
        //    Id = 0;
        //    Name = "Atlas";
        //    HitPoints = 10;
        //    Luck = 3;
        //}
        public Character()
        {

        }
        public Character(int id, string name, int hitPoints, int luck, int wealth)
        {
            Id = id;
            Name = name;
            HitPoints = hitPoints;
            Luck = luck;
            Wealth = wealth;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Luck { get; set; }
        public int Wealth { get; set; }
        public IList<Equipment> Equipment { get; set; }
        public string ErrorInsufficientValue { get; set; }
    }
}
