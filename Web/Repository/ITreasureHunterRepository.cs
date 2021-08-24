using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACDDS.TreasureHunter.Web.Models;

namespace ACDDS.TreasureHunter.Web.Repository
{
    public interface ITreasureHunterRepository
    {
        Task<List<CharactersResponse>> GetCharacters();
        Task<CharacterResponse> GetCharacter(int id);
        Task<IList<EquipmentResponse>> GetEquipmentList();
        Task<string> PurchaseEquipment(PurchaseRequest purchaseRequest);
    }
}
