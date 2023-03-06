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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            var games = await repository.GetAllGames();

            return Ok(mapper.Map<IEnumerable<GameReadDto>>(games));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetGameById(int id)
        {
            var game = await repository.GetGameById(id);
            if(game != null)
            {
                return Ok(mapper.Map<GameReadDto>(game));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewGame(GameCreateDto createDto)
        {
            var game = mapper.Map<Game>(createDto);

            await repository.CteateNewGame(game);
            await repository.SaveAsync();

            var gameReadDto = mapper.Map<GameReadDto>(game);

            return CreatedAtAction(nameof(GetGameById), new { Id = gameReadDto.Id }, gameReadDto);
        }

        [HttpDelete("{id:int}")]
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

        [HttpPatch]
        public async Task<ActionResult> MakeMove(int gameId, MoveDto move)
        {
            var game = await repository.GetGameById(gameId);
            if (game == null)
            {
                return NotFound($"Game with id: {gameId} not found");
            }

            if (game.Players.Exists(p => p.Id == move.PlayerId))
            {
                game.Cells[move.CellNumber].PlayerId = move.PlayerId;
                game.Cells[move.CellNumber].Value = move.Value;
                await repository.SaveAsync();
            }
            else
            {
                return NotFound($"Player with id: {move.PlayerId} doesn't partisipation in this game");
            }

            return NoContent();
        }
    }
}
