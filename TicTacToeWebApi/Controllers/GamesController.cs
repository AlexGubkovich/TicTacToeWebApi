using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicTacToeWebApi.Data;
using TicTacToeWebApi.DTOs;
using TicTacToeWebApi.Models;

namespace TicTacToeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository repository;
        private readonly IMapper mapper;

        public GamesController(IGameRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get all Games.
        /// </summary>
        /// <response code="200">Returns all games</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Game>>> GetAllGames()
        {
            var games = await repository.GetAllGames();

            return Ok(mapper.Map<IEnumerable<GameReadDto>>(games));
        }

        /// <summary>
        /// Get a specific Game.
        /// </summary>
        /// <response code="200">Returns specific game</response>        
        /// <response code="404">Game with such id doesn't exist</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetGameById(int id)
        {
            var game = await repository.GetGameById(id);
            if(game != null)
            {
                return Ok(mapper.Map<GameReadDto>(game));
            }

            return NotFound();
        }

        /// <summary>
        /// Create a new Game.
        /// </summary>
        /// <response code="201">Return created game</response>      
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateNewGame(GameCreateDto createDto)
        {
            var game = mapper.Map<Game>(createDto);

            await repository.CteateNewGame(game);
            await repository.SaveAsync();

            var gameReadDto = mapper.Map<GameReadDto>(game);

            return CreatedAtAction(nameof(GetGameById), new { gameReadDto.Id }, gameReadDto);
        }

        /// <summary>
        /// Deletes a specific Game.
        /// </summary>
        /// <response code="404">Game with such id doesn't exist</response>
        /// <response code="204">Game was succesfully deleted</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteGame(int id)
        {
            var game = await repository.GetGameById(id);
            if (game != null)
            {
                repository.DeleteGame(game);
                await repository.SaveAsync();
                return NoContent();
            }

            return NotFound();
        }

        /// <summary>
        /// Make move in a specific Game.
        /// </summary>
        /// <response code="404">
        ///     Game with such id doesn't exist or 
        ///     player with such id doesn't partisipation in this game
        /// </response>
        /// <response code="204">Move is made</response>
        [HttpPatch("{gameId:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> MakeMove(int gameId, MoveDto move)
        {
            var game = await repository.GetGameById(gameId);
            if (game == null)
            {
                return NotFound($"Game with id: {gameId} not found");
            }

            var player = game.Players.Find(p => p.Id == move.PlayerId);

            if (player != null)
            {
                var cell = game.Cells.Find(p => p.Number == move.CellNumber);
                if(cell != null)
                {
                    cell.PlayerId = move.PlayerId;
                    cell.Value = player.PlayerMoveType;
                    await repository.SaveAsync();
                }
            }
            else
            {
                return NotFound($"Player with id: {move.PlayerId} doesn't partisipation in this game");
            }

            return NoContent();
        }
    }
}
