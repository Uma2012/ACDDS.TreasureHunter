namespace ACDDS.TreasureHunter.Core.Models
{
    public class Equipment
    {
        private static int _idCounter = 0;

        public Equipment(string name, EquipmentType type, int hpModifier, int luckModifier, int value)
        {
            Id = (_idCounter++).ToString();
            Name = name;
            Type = type;
            HpModifier = hpModifier;
            LuckModifier = luckModifier;
            Value = value;
        }

        public string Id { get; }
        public string Name { get; }
        public EquipmentType Type { get; }
        public int HpModifier { get; }
        public int LuckModifier { get; }
        public int Value { get; }
    }
}
