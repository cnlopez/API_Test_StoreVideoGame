using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business.Interfaces;

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
        [HttpGet("getvideogames")]
        public async Task<ActionResult> GetVideogames()
        {
            return Ok(await _gameService.GetVideogames());
        }

        // GET: api/Videogames
        [HttpGet("getvideogamesmapper")]
        public async Task<ActionResult> GetVideogamesMapper()
        {
            return Ok(await _gameService.GetVideogamesMapper());
        }
    }
}
