using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACDDS.TreasureHunter.Web.Models;
using ACDDS.TreasureHunter.Web.Services;

namespace ACDDS.TreasureHunter.Web.Controllers
{
    public class TreasureHunterController : Controller
    {
        private readonly ITreasureHunterService _treasureHunterService;
        private static int _randNumber = -1;       

        public TreasureHunterController(ITreasureHunterService treasureHunterService)
        {
            this._treasureHunterService = treasureHunterService;
        }
        public async Task<ActionResult<CharacterResponse>> Character()
        {
            if (_randNumber == -1)
            {
                Random random = new Random();
                _randNumber = random.Next(0, 3);
            }

            var character = await _treasureHunterService.GetCharacterAttributes(_randNumber);            
            return View(character);
        }
        public async Task<ActionResult<IList<EquipmentResponse>>> Equipment()
        {
            var equipmets = await _treasureHunterService.GetEquipmentList();
            return View(equipmets);
        }

        public async Task<ActionResult> Purchase(string equipmentId)
        {
           PurchaseRequest purchaseRequest = new PurchaseRequest() { EquipmentId = equipmentId };
            
           var response= await _treasureHunterService.PurchaseEquipment(purchaseRequest);
            
            if (response == "BadRequest")
                TempData["BRMessage"] = "Sorry,Insufficient fund.";
            else if (response == "OK")
                TempData["OkMessage"] = "Hurry!! You Purchased an Equipment!";
            else if (response == "NotFound")
                TempData["NFMessage"] = "Equipment Not found";       
         
            return RedirectToAction("Character","TreasureHunter");
        }

    }
}
