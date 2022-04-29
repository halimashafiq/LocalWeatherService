
using LocalWeatherAPI.Models;
using LocalWeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace LocalWeatherAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocalWeatherController : ControllerBase
{
    private readonly LocalWeatherService _LocalWeatherService;

    public LocalWeatherController(LocalWeatherService LocalWeatherService) =>
        _LocalWeatherService = LocalWeatherService;

    [HttpGet]
    public async Task<List<LocalWeather>> GetAll()
    {
       return await _LocalWeatherService.GetAsync();
    }


    [HttpGet("{citycode:length(7)}")]
    public async Task<ActionResult<LocalWeather>> Get(int citycode)
    {
        var LocalWeather = await _LocalWeatherService.GetAsync(citycode);

        if (LocalWeather is null)
        {
            return NotFound();
        }

        return LocalWeather;
    }

    [HttpPost]
    public async Task<IActionResult> Post(int citycode, string cityname)
    {
        var LocalWeather = await _LocalWeatherService.GetAsync(citycode);
        LocalWeather newLocalWeather = new LocalWeather();

        if (LocalWeather is null)
        {
            newLocalWeather.CityCode = citycode;
            newLocalWeather.CityName = cityname;
            await _LocalWeatherService.CreateAsync(newLocalWeather);
            
        }

        return NoContent();
    }


    [HttpDelete]
    public async Task<IActionResult> Delete(int citycode)
    {
        var LocalWeather = await _LocalWeatherService.GetAsync(citycode);

        if (LocalWeather is null)
        {
            return NotFound();
        }

        await _LocalWeatherService.RemoveAsync(citycode);

        return NoContent();
    }
}