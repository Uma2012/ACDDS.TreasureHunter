using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Repository
{
    public interface ITreasureHunterRepository
    {
        Task<CharacterResponse> GetCharacterAttributes();
        Task<IList<EquipmentResponse>> GetEquipmentList();
        Task<string> PurchaseEquipment(PurchaseRequest purchaseRequest);
    }
}
