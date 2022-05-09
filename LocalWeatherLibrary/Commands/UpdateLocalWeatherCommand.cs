using LocalWeatherLibrary.Models;
using MediatR;

namespace LocalWeatherLibrary.Commands
{
    
    public record UpdateLocalWeatherCommand(string id, LocalWeather localWeather) : IRequest<LocalWeather>;


}
