using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    public interface ITreasureHunterService
    {
        Task<CharacterResponse> GetCharacterAttributes();
        Task<IList<EquipmentResponse>> GetEquipmentList();
        Task<string> PurchaseEquipment(PurchaseRequest purchaseRequest);
    }
}
