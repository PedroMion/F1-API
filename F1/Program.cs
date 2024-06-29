using Microsoft.EntityFrameworkCore;
using F1.Constants;
using F1.Services.Interfaces;
using F1.Services;
using F1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<F1Context>(options => {
    options.UseSqlServer(Private.SQL_CONNECTION);
});

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IDAL, DAL>();

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
