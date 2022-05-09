using Microsoft.EntityFrameworkCore;
using LocalWeatherLibrary.Models;
using MediatR;
using System.Reflection;
using LocalWeatherLibrary.Data;
using LocalWeatherAPI.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.Configure<LocalWeatherDatabaseSettings>(builder.Configuration.GetSection("LocalWeatherDatabase"));
builder.Services.AddSingleton<LocalWeatherService>();

//ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILocalWeatherService, LocalWeatherService>(); // Add data access to dependency container.
builder.Services.AddMediatR(typeof(LocalWeatherService).Assembly);

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

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<WorkerService>();
        services.AddSingleton<LocalWeatherService>();
        services.Configure<LocalWeatherDatabaseSettings>(builder.Configuration.GetSection("LocalWeatherDatabase"));
        services.AddScoped<ILocalWeatherService, LocalWeatherService>(); // Add data access to dependency container.
        services.AddMediatR(typeof(LocalWeatherService).Assembly);
    })
    .Build();

host.RunAsync();

app.Run();



