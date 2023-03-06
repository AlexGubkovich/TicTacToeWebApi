namespace TicTacToeWebApi.Models
{
    public class Game
    {
        public int Id { get; set; }

        public Cell[] Cells { get; set; } = new Cell[9];
        public List<Player> Players { get; set; } = null!;
    }
}
