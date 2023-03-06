using Microsoft.EntityFrameworkCore;
using TicTacToeWebApi.Configurations;
using TicTacToeWebApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GamesDbContext>(opt => opt.UseInMemoryDatabase("GameDb"));
builder.Services.AddScoped<IGameRepository, GameRepository>();

builder.Services.AddAutoMapper(typeof(MapperConfig));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
