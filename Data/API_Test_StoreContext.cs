using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class API_Test_StoreContext : DbContext
    {
        public API_Test_StoreContext(DbContextOptions<API_Test_StoreContext> options)
            : base(options)
        {
        }

        public DbSet<Videogames> Videogames { get; set; } = default!;
    }
}
