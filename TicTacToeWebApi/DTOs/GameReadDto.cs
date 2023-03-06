using TicTacToeWebApi.Models;

namespace TicTacToeWebApi.DTOs
{
    public class GameReadDto
    {
        public int Id { get; set; }

        public List<Cell> Cells { get; set; } = null!;
        public List<Player> Players { get; set; } = null!;
    }
}
