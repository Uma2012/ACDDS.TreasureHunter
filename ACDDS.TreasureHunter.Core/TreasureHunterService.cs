using System;
using System.Collections.Generic;
using System.Linq;
using ACDDS.TreasureHunter.Core.Exceptions;
using ACDDS.TreasureHunter.Core.Models;
using Microsoft.Extensions.Logging;

public class TreasureHunterService
{
    private readonly ILogger<TreasureHunterService> _logger;
    
    private readonly IList<Character> _character;    
    private int _characterWealth;
    private int _characterHitPoints;
    private int _characterLuck;
    private readonly IList<Equipment> _characterEquipment;

    private readonly IList<Equipment> _shopEquipment;

    public TreasureHunterService(ILogger<TreasureHunterService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _character = new List<Character>()
        { 
            new Character(0, "Ray", 6, 9, 200),
            new Character(1, "Atlas", 10, 3, 100),
            new Character(2, "Momo", 30, 0, 1000)
        };
       
        _characterEquipment = new List<Equipment>();
        _shopEquipment = new List<Equipment>()
        {
            new Equipment("Pantyhose of Giant Strength", EquipmentType.Armor, hpModifier: 5, luckModifier: 0, value: 20),
            new Equipment("Lucky Charm", EquipmentType.Trinket, hpModifier: 0, luckModifier: 7, value: 40),
            new Equipment("Lightsaber", EquipmentType.Weapon, hpModifier: 3, luckModifier: 5, value: 50),
            new Equipment("Diamond Tiara", EquipmentType.Armor, hpModifier: 1, luckModifier: 1, value: 1000)
        };
    }

    public Character GetCharacter(int id)
    {
        var character = _character.SingleOrDefault(c => c.Id ==id);
        _characterWealth = character.Wealth;
        _characterHitPoints = character.HitPoints;
        _characterLuck = character.Luck;        
        return character;
    }

    public int GetCharacterWealth()
    {
         return _characterWealth;      
    }

    public IEnumerable<Equipment> GetCharacterEquipment()
    {
        return _characterEquipment;        
    }

    public IEnumerable<Equipment> GetShopEquipment()
    {
        return _shopEquipment;
    }

    public Character Purchase(string equipmentId)
    {
        var equipment = _shopEquipment.SingleOrDefault(e => e.Id == equipmentId);
        if (equipment == null)
            throw new EquipmentNotFoundException(equipmentId);
        if (_characterWealth < equipment.Value)
        {            
            var character1 = new Character();
            character1.HitPoints = _characterHitPoints;
            character1.Luck = _characterLuck;
            character1.Wealth = _characterWealth;
            character1.Equipment = _characterEquipment;
            character1.ErrorInsufficientValue = "Insufficient Fund";
            return character1;
           // throw new InsufficientFundsException("Equipment value exceeds the character's wealth.", character1);
            
        }

        _characterWealth -= equipment.Value;
        _characterHitPoints += equipment.HpModifier;
        _characterLuck += equipment.LuckModifier;
        _shopEquipment.Remove(equipment);
        _characterEquipment.Add(equipment);

        var character = new Character();
        character.HitPoints = _characterHitPoints;
        character.Luck = _characterLuck;
        character.Wealth = _characterWealth;
        character.Equipment = _characterEquipment;
        return character;        

    }
}
