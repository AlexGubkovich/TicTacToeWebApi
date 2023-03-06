namespace TicTacToeWebApi.Models
{
    public class Game
    {
        public int Id { get; set; }

        public List<Cell> Cells { get; set; } = null!;
        public List<Player> Players { get; set; } = null!;
    }
}
