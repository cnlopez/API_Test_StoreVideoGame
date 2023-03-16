using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Game;

namespace Business.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<VideogamesViewModel>> GetVideoGames();
        Task<IEnumerable<VideogamesViewModel>> GetVideoGamesMapper();
        Task<VideogamesViewModel> GetVideoGamesMapper(int videoGameId);
        Task<int> SaveVideoGamesMapper(VideogamesViewModel videoGame);
    }
}
