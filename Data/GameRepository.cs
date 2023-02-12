using Data.Interfaces;
using Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class GameRepository : IGameRepository
    {
        private readonly IConfiguration _configuration;
        public GameRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Videogames>> GetVideogames()
        {
            var videoGames = new List<Videogames>();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_Test_StoreContext")))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("spGetVideogames", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = sqlCommand.ExecuteReader();
                while (rd.Read())
                {
                    videoGames.Add(new Videogames
                    {
                        VideogameId = rd.GetInt32("VideogameId"),
                        VideogameName = rd["VideogameName"].ToString(),
                        ConsoleId = rd.GetInt32("ConsoleId")
                    });
                }
            }
            return videoGames;
        }
    }
}
