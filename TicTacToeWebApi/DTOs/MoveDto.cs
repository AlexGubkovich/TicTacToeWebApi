using System.ComponentModel.DataAnnotations;
using TicTacToeWebApi.Models;

namespace TicTacToeWebApi.DTOs
{
    public class MoveDto
    {
        [Required]
        public int PlayerId { get; set; }

        [Required]
        [Range(1, 9)]
        public int CellNumber { get; set; }
    }
}
