using AutoMapper;
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
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        public GameService(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

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

        public async Task<IEnumerable<VideogamesViewModel>> GetVideogamesMapper()
        {
            var getVideoGames = await _gameRepository.GetVideogamesDapper();
            var videoGamesViewModel = _mapper.Map<IEnumerable<VideogamesViewModel>>(getVideoGames);
            return videoGamesViewModel;
        }
    }
}
