using Microsoft.EntityFrameworkCore;
using TicTacToeWebApi.Models;

namespace TicTacToeWebApi.Data
{
    public class GamesDbContext : DbContext
    {
        public GamesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
