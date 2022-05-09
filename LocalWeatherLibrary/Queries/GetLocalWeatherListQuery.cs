using LocalWeatherLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWeatherLibrary.Queries
{    
    public record GetLocalWeatherListQuery():IRequest<List<LocalWeather>>;
    
}
