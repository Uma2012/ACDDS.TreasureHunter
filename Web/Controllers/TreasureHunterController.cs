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
        private static string _characterName = "";

        public TreasureHunterController(ITreasureHunterService treasureHunterService)
        {
            this._treasureHunterService = treasureHunterService;
        }
        public async Task<ActionResult<CharacterResponse>> Character()
        {
            //if (_randNumber == -1)
            //{
                Random random = new Random();
                _randNumber = random.Next(0, 3);
            //}

            var character = await _treasureHunterService.GetCharacterAttributes(_randNumber);
            _characterName = character.Name;
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
            
           PurchaseResponse response= await _treasureHunterService.PurchaseEquipment(purchaseRequest);

            
            if (response.ErrorInsufficientValue == "Insufficient Fund")
                TempData["BRMessage"] = "Insufficient fund";
            else if (response.StatusResponse == "OK")
                TempData["OkMessage"] = "Equipment Purchased";
            else if (response.StatusResponse == "NotFound")
                TempData["NFMessage"] = "Equipment Not found";         
           

            CharacterResponse modifiedCharacterResponse = new CharacterResponse();
            modifiedCharacterResponse.HitPoints = response.HitPoints;
            modifiedCharacterResponse.Luck = response.Luck;
            modifiedCharacterResponse.Name = _characterName;
            modifiedCharacterResponse.Wealth = response.Wealth;
            modifiedCharacterResponse.Equipment = response.Equipment;
            
            return View("Character", modifiedCharacterResponse);
           // return RedirectToAction("Character","TreasureHunter");
        }

    }
}
