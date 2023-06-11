using Data.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
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
            var videoGames = Enumerable.Empty<Videogames>();
            using (IDbConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_Test_StoreContext")))
            {
                videoGames = await sqlConnection.QueryAsync<Videogames>("spGetVideogames", commandType: CommandType.StoredProcedure);
            }
            return videoGames;
        }

        public async Task<Videogames> GetVideoGame(int videoGameId)
        {
            var videoGames = new Videogames();
            using (IDbConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_Test_StoreContext")))
            {
                videoGames = await sqlConnection.QueryFirstAsync<Videogames>("spGetVideogameById", new { @VideogameId = videoGameId }, commandType: CommandType.StoredProcedure);
            }
            return videoGames;
        }

        public async Task<int> SaveVideogames(Videogames videoGame)
        {
            var videoGames = 0;
            using (IDbConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_Test_StoreContext")))
            {
                videoGames = await sqlConnection.QueryFirstAsync<int>("spSaveVideogame", new { videoGame.VideogameName, videoGame.ConsoleId }, commandType: CommandType.StoredProcedure);
            }
            return videoGames;
        }

        public async Task<int> UpdateVideogame(Videogames videoGame)
        {
            var videoGames = 0;
            using (IDbConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_Test_StoreContext")))
            {
                videoGames = await sqlConnection.QueryFirstAsync<int>("spUpdateVideogame", 
                                                new { videoGame.VideogameId, 
                                                      videoGame.VideogameName,
                                                      videoGame.ConsoleId,
                                                      videoGame.VideoGameTypeId
                                                }, commandType: CommandType.StoredProcedure);
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
