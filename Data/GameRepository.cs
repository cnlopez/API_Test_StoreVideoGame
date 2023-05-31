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
using Dapper;

namespace Data
{
    public class GameRepository : IGameRepository
    {
        private readonly IConfiguration _configuration;
        public GameRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Videogames>> GetVideoGames()
        {
            var videoGames = new List<Videogames>();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_Test_StoreContext")))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("spGetVideogames", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = await sqlCommand.ExecuteReaderAsync();
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

        public async Task<IEnumerable<Videogames>> GetVideoGamesDapper()
        {
            var videoGames = Enumerable.Empty<Videogames>();
            using (IDbConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_Test_StoreContext")))
            {
                videoGames = await sqlConnection.QueryAsync<Videogames>("spGetVideogames", commandType: CommandType.StoredProcedure);
            }
            return videoGames;
        }

        public async Task<Videogames> GetVideoGamesDapper(int videoGameId)
        {
            var videoGames = new Videogames();
            using (IDbConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_Test_StoreContext")))
            {
                videoGames = await sqlConnection.QueryFirstAsync<Videogames>("spGetVideogameById", new { @VideogameId = videoGameId }, commandType: CommandType.StoredProcedure);
            }
            return videoGames;
        }

        public async Task<int> SaveVideogamesMapper(Videogames videoGame)
        {
            var videoGames = 0;
            using (IDbConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_Test_StoreContext")))
            {
                videoGames = await sqlConnection.QueryFirstAsync<int>("spSaveVideogame", new { videoGame.VideogameName, videoGame.ConsoleId }, commandType: CommandType.StoredProcedure);
            }
            return videoGames;
        }

        public async Task<string> DeleteVideoGame(int videoGameId)
        {
            try
            {
                using (IDbConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_Test_StoreContext")))
                {
                    await sqlConnection.ExecuteAsync("spDeleteVideoGame", new { @VideogameId = videoGameId }, commandType: CommandType.StoredProcedure);
                }
                return "Done";
            }
            catch (Exception)
            {
                //throw new Exception("message");
                return "An error occurred";
            }
        }
    }
}
