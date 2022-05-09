using LocalWeatherLibrary.Models;
using MediatR;

namespace LocalWeatherLibrary.Commands
{
    public record DeleteLocalWeatherCommand(int CityCode):IRequest<LocalWeather>;
   
    

}
