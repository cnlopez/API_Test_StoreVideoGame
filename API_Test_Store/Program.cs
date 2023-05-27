using Microsoft.EntityFrameworkCore;
using Data;
using Services;
using API_Test_Store.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<API_Test_StoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("API_Test_StoreContext") ?? throw new InvalidOperationException("Connection string 'API_Test_StoreContext' not found.")));

// Add services to the container.
builder.Services.RegisterBusiness(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeLocalXmlComments();
});

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
