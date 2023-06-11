namespace Data.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Videogames>> GetVideoGames();
        Task<Videogames> GetVideoGame(int videoGameId);
        Task<int> SaveVideogames(Videogames videoGame);
        Task<int> UpdateVideogame(Videogames videoGame);
        Task<string> DeleteVideoGame(int videoGameId);
    }
}
