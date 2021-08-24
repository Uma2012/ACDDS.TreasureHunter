using ACDDS.TreasureHunter.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACDDS.TreasureHunter.Web.Extensions
{
    public static class ModelConversion
    {
        public static CharacterResponse ToCharacterResponseModel(this PurchaseResponse src)
        {
            return new CharacterResponse()
            {

                HitPoints = src.HitPoints,
                Luck = src.Luck,
                Wealth=src.Wealth,
                Equipment=src.Equipment


            };
        }
    }
}
