using TicTacToeWebApi.Models;

namespace TicTacToeWebApi.DTOs
{
    public class GameReadDto
    {
        public int Id { get; set; }

        public Cell[] Cells { get; set; } = new Cell[9];
    }
}
