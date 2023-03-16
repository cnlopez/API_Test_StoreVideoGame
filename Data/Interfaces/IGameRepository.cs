using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Videogames>> GetVideoGames();
        Task<IEnumerable<Videogames>> GetVideoGamesDapper();
        Task<Videogames> GetVideoGamesDapper(int videoGameId);
        Task<int> SaveVideogamesMapper(Videogames videoGame);
    }
}
