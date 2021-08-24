using System;
using ACDDS.TreasureHunter.Api.Models.Requests;
using ACDDS.TreasureHunter.Api.Models.Response;
using ACDDS.TreasureHunter.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ACDDS.TreasureHunter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PurchasesController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private readonly TreasureHunterService _treasureHunterService;

        public PurchasesController(
            ILogger<CharacterController> logger,
            TreasureHunterService treasureHunterService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _treasureHunterService = treasureHunterService ?? throw new ArgumentNullException(nameof(treasureHunterService));
        }

        [HttpPost()]
        public ActionResult<CharacterResponse> CreatePurchase([FromBody] PurchaseRequest request)
        {
            try
            {
               var responseCharacter= _treasureHunterService.Purchase(request.EquipmentId);
                //var response = new PurchaseResponse()
                //{
                //    EquipmentId = request.EquipmentId
                //};
                //if(responseCharacter.ErrorInsufficientValue!=null)
                //{
                //    return BadRequest(new
                //    {
                //        Message="Insuffient funds."
                //    });
                //}
                return Ok(responseCharacter);
            }
            catch (EquipmentNotFoundException)
            {
                return NotFound(new {
                    Message = "Equipment not found."
                });
            }
            //catch (InsufficientFundsException)
            //{
            //    return BadRequest(new { 
            //        Message = "Insufficient funds."
            //    });
            //}
        }
    }
}
