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
    [ApiController]
    public class VideogamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        public VideogamesController(IGameService gameService) => _gameService = gameService;

        /// <summary>
        /// Get video game
        /// </summary>
        /// <returns></returns>
        [Route("video-games"), HttpGet]
        public async Task<ActionResult> GetVideogamesMapper()
        {
            return Ok(await _gameService.GetVideoGames());
        }

        /// <summary>
        /// Get Video Games
        /// </summary>
        /// <param name="videoGameId"></param>
        /// <returns></returns>
        [Route("video-games/{videoGameId:int}"), HttpGet]
        public async Task<ActionResult> GetVideogamesMapper(int videoGameId)
        {
            return Ok(await _gameService.GetVideoGame(videoGameId));
        }

        /// <summary>
        /// Save Video game
        /// </summary>
        /// <param name="videoGame"></param>
        /// <returns></returns>
        [Route("video-games"), HttpPost]
        public async Task<ActionResult> SaveVideogamesMapper(VideogamesViewModel videoGame)
        {
            return Ok(await _gameService.SaveVideoGames(videoGame));
        }

        /// <summary>
        /// Update an existing video game
        /// </summary>
        /// <param name="videoGameId"></param>
        /// <param name="videoGame"></param>
        /// <returns></returns>
        [Route("video-games/{videoGameId:int}"), HttpPut]
        public async Task<ActionResult> UpdateVideogamesMapper(int videoGameId, VideogamesViewModel videoGame)
        {
            return Ok(await _gameService.UpdateVideoGames(videoGame));
        }

        /// <summary>
        /// Update an existing video game
        /// </summary>
        /// <param name="videoGameId"></param>
        /// <returns></returns>
        [Route("video-games/{videoGameId:int}"), HttpDelete]
        public async Task<ActionResult> DeleteVideogame(int videoGameId)
        {
            return Ok(await _gameService.DeleteVideoGame(videoGameId));
        }
    }
}
