using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACDDS.TreasureHunter.Web.Models;
using ACDDS.TreasureHunter.Web.Repository;

namespace ACDDS.TreasureHunter.Web.Services
{
    public class TreasureHunterService : ITreasureHunterService
    {
        private readonly ITreasureHunterRepository _treasureHunterRepository;

        public TreasureHunterService(ITreasureHunterRepository treasureHunterRepository)
        {
            this._treasureHunterRepository = treasureHunterRepository;
        }
        public async Task<CharacterResponse> GetCharacter(int id)
        {
            return await _treasureHunterRepository.GetCharacter(id);
        }

        public async Task<List<CharactersResponse>> GetCharacters()
        {
            return await _treasureHunterRepository.GetCharacters();
        }

        public async Task<IList<EquipmentResponse>> GetEquipmentList()
        {
            return await _treasureHunterRepository.GetEquipmentList();
        }

        public async Task<string> PurchaseEquipment(PurchaseRequest purchaseRequest)
        {
            return await _treasureHunterRepository.PurchaseEquipment(purchaseRequest);
        }
    }
}
