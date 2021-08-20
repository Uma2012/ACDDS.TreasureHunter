namespace ACDDS.TreasureHunter.Core.Models
{
    public class Character
    {
        public Character()
        {
            Id = 0;
            Name = "Atlas";
            HitPoints = 10;
            Luck = 3;
        }

        public int Id { get; }
        public string Name { get; }
        public int HitPoints { get; }
        public int Luck { get; }
    }
}
