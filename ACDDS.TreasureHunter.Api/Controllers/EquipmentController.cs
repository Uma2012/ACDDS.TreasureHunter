using System;
using System.Collections.Generic;
using System.Linq;
using ACDDS.TreasureHunter.Api.Extensions;
using ACDDS.TreasureHunter.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ACDDS.TreasureHunter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EquipmentController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private readonly TreasureHunterService _treasureHunterService;

        public EquipmentController(
            ILogger<CharacterController> logger,
            TreasureHunterService treasureHunterService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _treasureHunterService = treasureHunterService ?? throw new ArgumentNullException(nameof(treasureHunterService));
        }

        [HttpGet()]
        public IList<EquipmentResponse> GetEquipment()
        {
            var shopEquipment = _treasureHunterService
                .GetShopEquipment()
                .Select(ModelConversions.ToEquipmentResponseModel)
                .ToList();
            return shopEquipment;
        }
    }
}
