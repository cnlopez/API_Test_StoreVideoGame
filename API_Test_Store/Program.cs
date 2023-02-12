using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using API_Test_Store.Data;
//using API_Test_Store.Business.Interfaces;
//using API_Test_Store.Business.Services;
using Data;
using Data.Interfaces;
using Business.Interfaces;
using Business.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<API_Test_StoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("API_Test_StoreContext") ?? throw new InvalidOperationException("Connection string 'API_Test_StoreContext' not found.")));

// Add services to the container.
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGameRepository, GameRepository>();


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
