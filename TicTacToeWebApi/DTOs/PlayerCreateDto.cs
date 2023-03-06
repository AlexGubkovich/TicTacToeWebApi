using TicTacToeWebApi.Models;

namespace TicTacToeWebApi.DTOs
{
    public class PlayerCreateDto
    {
        public string Name { get; set; } = null!;
        public CellValues PlayerMoveType { get; set; }
    }
}
