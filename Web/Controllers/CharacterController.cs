using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ITreasureHunterService _treasureHunterService;

        public CharacterController(ITreasureHunterService treasureHunterService)
        {
            this._treasureHunterService = treasureHunterService;
        }
        public async Task<ActionResult<CharacterResponse>> Character()
        {
            var character = await _treasureHunterService.GetCharacterAttributes();
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

            if (response == "OK")
                ViewBag.Message = "Equipment Purchased";
            else if (response == "BadRequest")
                ViewBag.Message = "Insufficient fund";
            else if (response == "NotFound")
                ViewBag.Message = "Equipment Not found";
                
            return View();
        }

    }
}
