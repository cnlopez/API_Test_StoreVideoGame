using Business.Interfaces;
using Data.Interfaces;
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
            var getVideoGames = await _gameRepository.GetVideoGames();
            var videoGamesViewModel = _mapper.Map<IEnumerable<VideogamesViewModel>>(getVideoGames);
            return videoGamesViewModel;
        }

        public async Task<VideogamesViewModel> GetVideoGame(int videoGameId)
        {
            var getVideoGames = await _gameRepository.GetVideoGame(videoGameId);
            var videoGamesViewModel = _mapper.Map<VideogamesViewModel>(getVideoGames);
            var gameName = videoGamesViewModel.GetVideoGameName();
            var type = VideoGameType.Action;

            return videoGamesViewModel;
        }

        public async Task<int> SaveVideoGames(VideogamesViewModel videoGame)
        {
            var videoGames = _mapper.Map<Videogames>(videoGame);
            var getVideoGames = await _gameRepository.SaveVideogames(videoGames);
            return getVideoGames;
        }

        public async Task<int> UpdateVideoGames(VideogamesViewModel videoGame)
        {
            var videoGames = _mapper.Map<Videogames>(videoGame);
            var getVideoGames = await _gameRepository.UpdateVideogame(videoGames);
            return getVideoGames;
        }

        public async Task<string> DeleteVideoGame(int videoGameId)
        {
            var deleteVideoGames = await _gameRepository.DeleteVideoGame(videoGameId);
            return deleteVideoGames;
        }
    }
}
