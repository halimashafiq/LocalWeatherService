using LocalWeatherLibrary.Data;
using LocalWeatherLibrary.Models;
using LocalWeatherLibrary.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LocalWeatherLibrary.Handlers
{
    public class GetLocalWeatherListHandler : IRequestHandler<GetLocalWeatherListQuery, List<LocalWeather>>
    {
        private readonly ILocalWeatherService _LocalWeatherService;

        public GetLocalWeatherListHandler(ILocalWeatherService LocalWeatherService)
        {
            _LocalWeatherService = LocalWeatherService;
        }
        public Task<List<LocalWeather>> Handle(GetLocalWeatherListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_LocalWeatherService.GetLocalWhether());
        }
    }
}
