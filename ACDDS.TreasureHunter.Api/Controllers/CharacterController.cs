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
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private readonly TreasureHunterService _treasureHunterService;

        public CharacterController(
            ILogger<CharacterController> logger,
            TreasureHunterService treasureHunterService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _treasureHunterService = treasureHunterService ?? throw new ArgumentNullException(nameof(treasureHunterService));
        }

        [HttpGet()]
        public CharacterResponse GetCharacter(int id)
        {
            var character = _treasureHunterService.GetCharacter(id);
            var characterWealth = _treasureHunterService.GetCharacterWealth();
            var characterEquipment = _treasureHunterService
                .GetCharacterEquipment()
                .Select(ModelConversions.ToEquipmentResponseModel)
                .ToList();
            return new CharacterResponse {
                Name = character.Name,
                HitPoints = character.HitPoints,
                Luck = character.Luck,
                Wealth = characterWealth,
                Equipment = characterEquipment
            };
        }

        [HttpGet()]
        public List<CharactersResponse> GetCharacters()
        {
            var characters = _treasureHunterService
                .GetCharacters()
                .Select(ModelConversions.ToCharactersResponseModel)
                .ToList();
            return characters;
        }
    }
}
