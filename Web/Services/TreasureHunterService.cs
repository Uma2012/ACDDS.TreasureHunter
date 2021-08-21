using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Repository;

namespace Web.Services
{
    public class TreasureHunterService : ITreasureHunterService
    {
        private readonly ITreasureHunterRepository _treasureHunterRepository;

        public TreasureHunterService(ITreasureHunterRepository treasureHunterRepository)
        {
            this._treasureHunterRepository = treasureHunterRepository;
        }
        public async Task<CharacterResponse> GetCharacterAttributes()
        {
            return await _treasureHunterRepository.GetCharacterAttributes();
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
