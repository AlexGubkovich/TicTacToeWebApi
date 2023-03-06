using System.ComponentModel.DataAnnotations;
using TicTacToeWebApi.Models;

namespace TicTacToeWebApi.DTOs
{
    public class MoveDto
    {
        [Required]
        public int PlayerId { get; set; }

        [Required]
        public int CellNumber { get; set; }

        [Required]
        public CellValues Value { get; set; }
    }
}
