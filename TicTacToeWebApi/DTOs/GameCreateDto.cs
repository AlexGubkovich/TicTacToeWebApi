using System.ComponentModel.DataAnnotations;
using TicTacToeWebApi.Models;

namespace TicTacToeWebApi.DTOs
{
    public class GameCreateDto : IValidatableObject
    {
        [Required]
        public List<PlayerCreateDto> Players { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Players.Count != 2)
            {
                errors.Add(new ValidationResult("Count of players should equals two"));
            }

            return errors;
        }
    }
}
