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
        private static int _characterId = -1;
       

        public TreasureHunterController(ITreasureHunterService treasureHunterService)
        {
            this._treasureHunterService = treasureHunterService;
        }

        public async Task<ActionResult<List<CharactersResponse>>> Characters()
        {
            var characters = await _treasureHunterService.GetCharacters();
            return View(characters);
        }
        public async Task<ActionResult<CharacterResponse>> Character(int id)
        {
            //Keeping the character id consistent
            if (_characterId == -1)
            {
                _characterId = id;
                TempData["CharacterId"] = id;
                TempData.Keep("CharacterId");
            }
            var character = await _treasureHunterService.GetCharacter(_characterId);            
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
         
            return RedirectToAction("Character","TreasureHunter", new {id= _characterId });
        }

    }
}
