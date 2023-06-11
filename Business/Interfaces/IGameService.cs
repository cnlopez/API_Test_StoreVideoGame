namespace Business.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<VideogamesViewModel>> GetVideoGames();
        Task<VideogamesViewModel> GetVideoGame(int videoGameId);
        Task<int> SaveVideoGames(VideogamesViewModel videoGame);
        Task<int> UpdateVideoGames(VideogamesViewModel videoGame);
        Task<string> DeleteVideoGame(int videoGameId);
    }
}
