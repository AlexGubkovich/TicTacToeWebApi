using AutoMapper;
using TicTacToeWebApi.DTOs;
using TicTacToeWebApi.Models;

namespace TicTacToeWebApi.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Game, GameReadDto>();
            CreateMap<GameReadDto, Game>();
            CreateMap<GameCreateDto, Game>();

            CreateMap<PlayerCreateDto, Player>();
        }
    }
}
