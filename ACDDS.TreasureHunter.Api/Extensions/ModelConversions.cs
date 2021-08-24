﻿using ACDDS.TreasureHunter.Api.Models.Response;
using ACDDS.TreasureHunter.Core.Models;

namespace ACDDS.TreasureHunter.Api.Extensions
{
    public static class ModelConversions
    {
        public static EquipmentResponse ToEquipmentResponseModel(this Equipment src)
        {
            return new EquipmentResponse()
            {
                Id = src.Id,
                Name = src.Name,
                Type = src.Type.ToString(),
                HpModifier = src.HpModifier,
                LuckModifier = src.LuckModifier,
                Value = src.Value
            };
        }
        public static CharactersResponse ToCharactersResponseModel(this Character src)
        {
            return new CharactersResponse()
            {
                Id = src.Id,
                Name = src.Name,
                HitPoints = src.HitPoints,
                Luck = src.Luck,
                Wealth = src.Wealth
            };
        }
    }
}
