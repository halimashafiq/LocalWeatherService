using LocalWeatherLibrary.Commands;
using LocalWeatherLibrary.Data;
using LocalWeatherLibrary.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LocalWeatherLibrary.Handlers
{
    public class UpdateLocalWeatherHandler : IRequestHandler<UpdateLocalWeatherCommand, LocalWeather>
    {
        private readonly ILocalWeatherService _LocalWeatherService;

        public UpdateLocalWeatherHandler(ILocalWeatherService LocalWeatherService)
        {
            _LocalWeatherService = LocalWeatherService;
        }  

        public Task<LocalWeather> Handle(UpdateLocalWeatherCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_LocalWeatherService.UpdateLocalWeather(request.id,request.localWeather));
        }

    }
}
