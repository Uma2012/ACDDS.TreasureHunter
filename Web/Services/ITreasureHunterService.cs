using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACDDS.TreasureHunter.Web.Models;

namespace ACDDS.TreasureHunter.Web.Services
{
    public interface ITreasureHunterService
    {
        Task<List<CharactersResponse>> GetCharacters();
        Task<CharacterResponse> GetCharacter(int id);
        Task<IList<EquipmentResponse>> GetEquipmentList();
        Task<string> PurchaseEquipment(PurchaseRequest purchaseRequest);
    }
}
