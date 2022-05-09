using LocalWeatherLibrary.Models;
using MediatR;

namespace LocalWeatherLibrary.Commands
{
    public record AddLocalWeatherCommand(int CityCode,string CityName):IRequest<LocalWeather>;
    //public record AddLocalWeatherfullCommand(LocalWeather localWeather) : IRequest<LocalWeather>;
   
    

}
