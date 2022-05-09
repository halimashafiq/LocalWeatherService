using LocalWeatherLibrary.Models;
using MediatR;

namespace LocalWeatherLibrary.Queries
{
    // Accept a int parameter and return an LocalWeather Model
    public record GetLocalWeatherByIdQuery(int citycode) :IRequest<LocalWeather>; 
   
}
