﻿using System;
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
        [HttpGet("video-games")]
        public async Task<ActionResult> GetVideogamesMapper()
        {
            return Ok(await _gameService.GetVideoGamesMapper());
        }

        // GET: api/Videogames
        [HttpGet("video-games/{videoGameId:int}")]
        public async Task<ActionResult> GetVideogamesMapper(int videoGameId)
        {
            return Ok(await _gameService.GetVideoGamesMapper(videoGameId));
        }

        // POST: api/Videogames
        [HttpPost("video-games")]
        public async Task<ActionResult> SaveVideogamesMapper(VideogamesViewModel videoGame)
        {
            return Ok(await _gameService.SaveVideoGamesMapper(videoGame));
        }

        /// <summary>
        /// Update an existing video game
        /// </summary>
        /// <param name="videoGameId"></param>
        /// <param name="videoGame"></param>
        /// <returns></returns>
        [HttpPut("video-games/{videoGameId:int}")]
        public async Task<ActionResult> UpdateVideogamesMapper(int videoGameId, VideogamesViewModel videoGame)
        {
            return Ok(await _gameService.SaveVideoGamesMapper(videoGame));
        }
    }
}
