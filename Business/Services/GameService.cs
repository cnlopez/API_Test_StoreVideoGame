using Business.Interfaces;
using Data;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Game;

namespace Business.Services
{
    public class GameService : IGameService
    {
        private readonly API_Test_StoreContext _context;
        private readonly IGameRepository _gameRepository;
        public GameService(API_Test_StoreContext context, IGameRepository gameRepository)
        {
            _context = context;
            _gameRepository = gameRepository;
        }
        //public async Task<IEnumerable<Videogames>> GetVideogames()
        //{
        //    return await _context.Videogames.ToListAsync();
        //}

        public async Task<IEnumerable<VideogamesViewModel>> GetVideogames()
        {
            var getVideoGames = _gameRepository.GetVideogames();

            var videoGamesViewModel = new List<VideogamesViewModel>();

            foreach (var game in await getVideoGames) 
            {
                videoGamesViewModel.Add(new VideogamesViewModel
                {
                    VideogameId = game.VideogameId,
                    VideogameName = game.VideogameName,
                    ConsoleId = game.ConsoleId
                });
            }
            return videoGamesViewModel;
        }
    }
}
