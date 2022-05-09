using LocalWeatherLibrary.Commands;
using LocalWeatherLibrary.Data;
using LocalWeatherLibrary.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LocalWeatherLibrary.Handlers
{
    public class DeletLocalWeatherHandler : IRequestHandler<DeleteLocalWeatherCommand, LocalWeather>
    {
        private readonly ILocalWeatherService _LocalWeatherService;

        public DeletLocalWeatherHandler(ILocalWeatherService LocalWeatherService)
        {
            _LocalWeatherService = LocalWeatherService;
        }
        public Task<LocalWeather> Handle(DeleteLocalWeatherCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_LocalWeatherService.DeleteLocalWeather(request.CityCode));
        }

      


    }
}
