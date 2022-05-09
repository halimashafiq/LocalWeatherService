using LocalWeatherLibrary.Commands;
using LocalWeatherLibrary.Data;
using LocalWeatherLibrary.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LocalWeatherLibrary.Handlers
{
    public class AddLocalWeatherHandler : IRequestHandler<AddLocalWeatherCommand, LocalWeather>
    {
        private readonly ILocalWeatherService _LocalWeatherService;

        public AddLocalWeatherHandler(ILocalWeatherService LocalWeatherService)
        {
            _LocalWeatherService = LocalWeatherService;
        }
        public Task<LocalWeather> Handle(AddLocalWeatherCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_LocalWeatherService.AddLocalWeather(request.CityCode, request.CityName));
        }

        //public Task<LocalWeather> Handle(AddLocalWeatherfullCommand request, CancellationToken cancellationToken)
        //{
        //    return Task.FromResult(_LocalWeatherService.AddLocalWeather(request.localWeather));
        //}


    }
}
