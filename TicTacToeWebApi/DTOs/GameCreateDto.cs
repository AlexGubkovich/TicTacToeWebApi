using System.ComponentModel.DataAnnotations;

namespace TicTacToeWebApi.DTOs
{
    public class GameCreateDto : IValidatableObject
    {
        [Required]
        public List<PlayerCreateDto> Players { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new();

            if (Players.Count != 2)
            {
                errors.Add(new ValidationResult("Count of players should equals two"));
            }

            if (Players[0].PlayerMoveType == Players[1].PlayerMoveType)
            {
                errors.Add(new ValidationResult("Players must have different types of moves"));
            }

            return errors;
        }
    }
}