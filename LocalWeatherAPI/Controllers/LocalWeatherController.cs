
using LocalWeatherLibrary.Models;
using LocalWeatherLibrary.Commands;
using LocalWeatherLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace LocalWeatherAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocalWeatherController : ControllerBase
{
    //private readonly LocalWeatherService _LocalWeatherService;
    private readonly IMediator _mediator;

    public LocalWeatherController(IMediator mediator) => _mediator = mediator;


    // GET: api/<LocalWeathersController>
    [HttpGet]
    public async Task<List<LocalWeather>> GetAll()
    {
        return await _mediator.Send(new GetLocalWeatherListQuery());
    }

    [HttpGet("{citycode}")]
    public async Task<LocalWeather> Get(int citycode)
    {
        return await _mediator.Send(new GetLocalWeatherByIdQuery(citycode));
    }

    [HttpPost]
    public async Task<LocalWeather> Post(int citycode, string cityname)
    {
        return await _mediator.Send(new AddLocalWeatherCommand(citycode, cityname));
    }

    [HttpDelete]
    public async Task<LocalWeather> Delete(int citycode)
    {
        return await _mediator.Send(new DeleteLocalWeatherCommand(citycode));

    }















    //public LocalWeatherController(LocalWeatherService LocalWeatherService) =>
    //    _LocalWeatherService = LocalWeatherService;

    //[HttpGet]
    //public async Task<List<LocalWeather>> GetAll()
    //{
    //   return await _LocalWeatherService.GetAsync();
    //}


    //[HttpGet("{citycode:length(7)}")]
    //public async Task<ActionResult<LocalWeather>> Get(int citycode)
    //{
    //    var LocalWeather = await _LocalWeatherService.GetAsync(citycode);

    //    if (LocalWeather is null)
    //    {
    //        return NotFound();
    //    }

    //    return LocalWeather;
    //}

    //[HttpPost]
    //public async Task<IActionResult> Post(int citycode, string cityname)
    //{
    //    var LocalWeather = await _LocalWeatherService.GetAsync(citycode);
    //    LocalWeather newLocalWeather = new LocalWeather();

    //    if (LocalWeather is null)
    //    {
    //        newLocalWeather.CityCode = citycode;
    //        newLocalWeather.CityName = cityname;
    //        await _LocalWeatherService.CreateAsync(newLocalWeather);

    //    }

    //    return NoContent();
    //}


    //[HttpDelete]
    //public async Task<IActionResult> Delete(int citycode)
    //{
    //    var LocalWeather = await _LocalWeatherService.GetAsync(citycode);

    //    if (LocalWeather is null)
    //    {
    //        return NotFound();
    //    }

    //    await _LocalWeatherService.RemoveAsync(citycode);

    //    return NoContent();
    //}
}