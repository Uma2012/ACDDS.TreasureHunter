namespace ACDDS.TreasureHunter.Api.Models.Response
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
