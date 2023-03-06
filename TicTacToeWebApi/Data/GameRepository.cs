using Microsoft.EntityFrameworkCore;
using TicTacToeWebApi.Models;

namespace TicTacToeWebApi.Data
{
    public class GameRepository : IGameRepository
    {
        private readonly GamesDbContext context;

        public GameRepository(GamesDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Game>> GetAllGames() =>
            await context.Games.ToListAsync();

        public async Task<Game?> GetGameById(int id) =>
            await context.Games
                .Include(p => p.Players)
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task CteateNewGame(Game game)
        {
            for (int i = 0; i < 9; i++)
            {
                game.Cells[i] = new() { Number = i + 1 };
            }

            await context.Players.AddRangeAsync(game.Players);
            await context.Games.AddAsync(game);
        }

        public void DeleteGame(Game game)
        {
            context.Games.Remove(game);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
