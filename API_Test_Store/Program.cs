using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Data;
using Data.Interfaces;
using Business.Interfaces;
using Business.Services;
using AutoMapper;
using Business.Mappers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<API_Test_StoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("API_Test_StoreContext") ?? throw new InvalidOperationException("Connection string 'API_Test_StoreContext' not found.")));

// Add services to the container.
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGameRepository, GameRepository>();

var mapperConfig = new MapperConfiguration(m =>
{
    m.AddProfile(new VideoGamesProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
