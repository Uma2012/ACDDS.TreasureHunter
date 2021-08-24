using System;
using System.Collections.Generic;
using System.Linq;
using ACDDS.TreasureHunter.Core.Exceptions;
using ACDDS.TreasureHunter.Core.Models;
using Microsoft.Extensions.Logging;

public class TreasureHunterService
{
    private readonly ILogger<TreasureHunterService> _logger;
    
    private readonly IList<Character> _characters;
    private Character _character;    
    private readonly IList<Equipment> _characterEquipment;
    private readonly IList<Equipment> _shopEquipment;

    public TreasureHunterService(ILogger<TreasureHunterService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _characters = new List<Character>()
        { 
            new Character(0, "Ray", 6, 9, 200),
            new Character(1, "Atlas", 10, 3, 100),
            new Character(2, "Momo", 30, 0, 1000)
        };
       
        _characterEquipment = new List<Equipment>();
        _character = new Character();
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
        var character = _characters.SingleOrDefault(c => c.Id ==id);              
        _character = character;
        return _character;
    }

    public int GetCharacterWealth()
    {           
        return _character.Wealth;
    }

    public IEnumerable<Equipment> GetCharacterEquipment()
    {
        return _characterEquipment;        
    }

    public IEnumerable<Equipment> GetShopEquipment()
    {
        return _shopEquipment;
    }

    public void Purchase(string equipmentId)
    {        
        var equipment = _shopEquipment.SingleOrDefault(e => e.Id == equipmentId);
        if (equipment == null)
            throw new EquipmentNotFoundException(equipmentId);
        if (_character.Wealth < equipment.Value)                    
            throw new InsufficientFundsException("Equipment value exceeds the character's wealth.");                     

        _character.Wealth -= equipment.Value;
        _character.HitPoints += equipment.HpModifier;
        _character.Luck += equipment.LuckModifier;
        _character.Equipment = _characterEquipment;
        _shopEquipment.Remove(equipment);
        _characterEquipment.Add(equipment);      

    }
}
