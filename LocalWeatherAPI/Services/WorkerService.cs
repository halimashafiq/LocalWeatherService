using LocalWeatherAPI.Controllers;
using LocalWeatherAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LocalWeatherAPI.Services
{

    public class WorkerService : BackgroundService
    {
        private readonly ILogger<WorkerService> _logger;
        private static readonly HttpClient client = new HttpClient();
        private readonly LocalWeatherService _LocalWeatherService;

        public WorkerService(ILogger<WorkerService> logger, LocalWeatherService LocalWeatherService)
        { 
            _LocalWeatherService = LocalWeatherService;      
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                
                List<LocalWeather> localWhethers = await _LocalWeatherService.GetAsync();

                foreach (LocalWeather weather in localWhethers)
                {
                    if (weather == null)
                        continue;
                    else

                    {
                        using (var client = new HttpClient())
                        {
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                            var response = await client.GetAsync("http://api.openweathermap.org/data/2.5/weather?id=" + weather.CityCode + "&appid=ba8b8bdcdbbffbe7986cde20f4dc5ccb");
                            response.EnsureSuccessStatusCode();

                            var responseString = await response.Content.ReadAsStringAsync();
                            var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(responseString);

                            var localweather = new LocalWeather
                            {

                                Id = weather.Id,
                                CityCode = weather.CityCode,
                                CityName = weather.CityName,

                                Temperature = weatherInfo.Main.Temp.Value,
                                Pressure = weatherInfo.Main.Pressure.Value,
                                Humidity = weatherInfo.Main.Humidity.Value,
                                WindSpeed = weatherInfo.Wind.Speed.Value,
                                Description = weatherInfo.Weather[0].Description

                            };
                            await _LocalWeatherService.UpdateAsync(weather.Id, localweather); 

                        }
                    }
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }
    }
}