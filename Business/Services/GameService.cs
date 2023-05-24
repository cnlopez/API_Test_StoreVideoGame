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
using ViewModels.Enums;
using Extensions;

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

        public async Task<IEnumerable<VideogamesViewModel>> GetVideoGames()
        {
            var getVideoGames = _gameRepository.GetVideoGames();

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

        public async Task<IEnumerable<VideogamesViewModel>> GetVideoGamesMapper()
        {
            var getVideoGames = await _gameRepository.GetVideoGamesDapper();
            var videoGamesViewModel = _mapper.Map<IEnumerable<VideogamesViewModel>>(getVideoGames);
            return videoGamesViewModel;
        }

        public async Task<VideogamesViewModel> GetVideoGamesMapper(int videoGameId)
        {
            var getVideoGames = await _gameRepository.GetVideoGamesDapper(videoGameId);
            var videoGamesViewModel = _mapper.Map<VideogamesViewModel>(getVideoGames);
            var gameName = videoGamesViewModel.GetVideoGameName();
            var type = VideoGameType.Action;

            return videoGamesViewModel;
        }

        public async Task<int> SaveVideoGamesMapper(VideogamesViewModel videoGame)
        {
            var videoGames = _mapper.Map<Videogames>(videoGame);
            var getVideoGames = await _gameRepository.SaveVideogamesMapper(videoGames);
            return getVideoGames;
        }
    }
}
