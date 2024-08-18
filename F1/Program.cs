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

builder.Services.AddStackExchangeRedisCache(redisOption => {
    redisOption.Configuration = Private.REDIS_CONNECTION;
});

builder.Services.AddCors(options =>
{
        options.AddPolicy(Private.CORS_POLICY,
            builder => builder
                .WithOrigins(Private.CORS_CONNECTION)
                .AllowAnyMethod()
                .AllowAnyHeader());
});

builder.Services.AddScoped<IDAL, DAL>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IDataService, DataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(Private.CORS_POLICY);

app.MapControllers();

app.Run();
