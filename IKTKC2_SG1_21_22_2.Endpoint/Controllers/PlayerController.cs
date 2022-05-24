using IKTKC2_SG1_21_22_2.Logic;
using IKTKC2_SG1_21_22_2.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IKTKC2_SG1_21_22_2.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            return Ok(playerService.GetAllPlayers());
        }

        [HttpGet("{playerId}")]
        public IActionResult GetPlayerById(int playerId)
        {
            return Ok(playerService.GetPlayerById(playerId));
        }

        [HttpPost] 
        public IActionResult AddPlayer(PlayerDto addedPlayer)
        {
            try
            {
                playerService.AddPlayer(addedPlayer);
                return Ok("Player is added!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{playerId}")]
        public IActionResult UpdatePlayer([FromRoute] int playerId, [FromBody] PlayerDto updatedPlayer)
        {
            try
            { 
                playerService.UpdatePlayer(playerId, updatedPlayer);
                return Ok("Player is updated!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{playerId}")]
        public IActionResult DeletePlayerById(int playerId)
        {
            playerService.DeletePlayerById(playerId);
            return Ok("Player is deleted!");
        }
    }
}
