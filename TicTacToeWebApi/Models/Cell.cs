using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TicTacToeWebApi.Models
{
    [Owned]
    public class Cell
    {
        public int Number { get; set; }

        public CellValues? Value { get; set; }
        public int? PlayerId { get; set; }
    }
}
