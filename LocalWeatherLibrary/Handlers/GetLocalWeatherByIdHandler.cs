using LocalWeatherLibrary.Data;
using LocalWeatherLibrary.Models;
using LocalWeatherLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalWeatherLibrary.Handlers
{
    public class GetLocalWeatherByIdHandler : IRequestHandler<GetLocalWeatherByIdQuery, LocalWeather>
    {
        private readonly IMediator _mediator;
        private readonly ILocalWeatherService _LocalWeatherService;
        public GetLocalWeatherByIdHandler(ILocalWeatherService localWeatherService)
        {
            _LocalWeatherService = localWeatherService;
        }
       
        public Task<LocalWeather> Handle(GetLocalWeatherByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_LocalWeatherService.GetByCityCode(request.citycode));
        }
    }
}
