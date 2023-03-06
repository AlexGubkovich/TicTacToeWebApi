using TicTacToeWebApi.Models;

namespace TicTacToeWebApi.Data
{
    public interface IGameRepository
    {
        Task CteateNewGame(Game game);
        void DeleteGame(Game game);
        Task<IEnumerable<Game>> GetAllGames();
        Task<Game?> GetGameById(int id);
        Task SaveAsync();
    }
}