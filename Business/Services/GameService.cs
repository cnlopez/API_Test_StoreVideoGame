using Business.Interfaces;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class GameService : IGameService
    {
        private readonly API_Test_StoreContext _context;
        public GameService(API_Test_StoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Videogames>> GetVideogames()
        {
            return await _context.Videogames.ToListAsync();
        }
    }
}
