using Microsoft.EntityFrameworkCore;
using LocalWeatherAPI.Models;
using LocalWeatherAPI.Services;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.Configure<LocalWeatherDatabaseSettings>(builder.Configuration.GetSection("LocalWeatherDatabase"));
builder.Services.AddSingleton<LocalWeatherService>();

//This is the depedency for the appsettings json
ConfigurationManager configuration = builder.Configuration;

//Registering our database
builder.Services.AddControllers();

//Registering AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<WorkerService>();
        services.AddSingleton<LocalWeatherService>();
        services.Configure<LocalWeatherDatabaseSettings>(builder.Configuration.GetSection("LocalWeatherDatabase"));
    })
    .Build();

host.RunAsync();

app.Run();


