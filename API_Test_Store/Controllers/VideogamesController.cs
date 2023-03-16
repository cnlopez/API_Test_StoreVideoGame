using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business.Interfaces;
using ViewModels.Game;

namespace API_Test_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideogamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        public VideogamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        // GET: api/Videogames
        [HttpGet("videogames")]
        public async Task<ActionResult> GetVideogames()
        {
            return Ok(await _gameService.GetVideoGames());
        }

        // GET: api/Videogames
        [HttpGet("videogamesmapper")]
        public async Task<ActionResult> GetVideogamesMapper()
        {
            return Ok(await _gameService.GetVideoGamesMapper());
        }

        // GET: api/Videogames
        [HttpGet("videogamemapper")]
        public async Task<ActionResult> GetVideogamesMapper(int videoGameId)
        {
            return Ok(await _gameService.GetVideoGamesMapper(videoGameId));
        }

        // GET: api/Videogames
        [HttpPost("savevideogamemapper")]
        public async Task<ActionResult> SaveVideogamesMapper(VideogamesViewModel videoGame)
        {
            return Ok(await _gameService.SaveVideoGamesMapper(videoGame));
        }

        // GET: api/Videogames
        [HttpPut("updatevideogamemapper")]
        public async Task<ActionResult> UpdateVideogamesMapper(VideogamesViewModel videoGame)
        {
            return Ok(await _gameService.SaveVideoGamesMapper(videoGame));
        }
    }
}
