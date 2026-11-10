using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameApp.API.Data;
using GameApp.API.Models;
using GameApp.API.Repostiories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameApp.API.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository gameRepository;
        public GamesController(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var games = await gameRepository.GetAllAsync();

            return Ok(games);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var game = await gameRepository.GetByIdAsync(id);
            if(game == null) return NotFound();

            return Ok(game);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Game game)
        {
            var existingGame = await gameRepository.UpdateAsync(id, game);
            if(existingGame == null) return NotFound();

            return Ok(existingGame);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Game game)
        {
            await gameRepository.CreateAsync(game);

            return CreatedAtAction(nameof(GetById), new { id = game.Id } , game);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var game = await gameRepository.DeleteAsync(id);
            if(game == null) return NotFound();

            return Ok();
        }
    }
}