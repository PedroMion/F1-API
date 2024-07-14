using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1.Data.DTO;
using F1.Services;
using F1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace F1.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;

        public GameController(IGameService gameService)
        {
            _service = gameService;
        }

        [HttpGet()]
        public async Task<ActionResult<GameDto>> GetTodayGame([BindRequired] String? date)
        {
            if (_service.InvalidDate(date)) {
                return BadRequest("Invalid date parameter");
            }
            
            var game = await _service.GetGameByDate(date);

            if (game == null) {
                return NoContent();
            }

            return Ok(game);
        }
    } 
}