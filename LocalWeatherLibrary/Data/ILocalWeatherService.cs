using LocalWeatherLibrary.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LocalWeatherLibrary.Data
{
    public interface ILocalWeatherService
    {
        
        public List<LocalWeather> GetLocalWhether();
        public LocalWeather GetByCityCode(int citycode);
        public LocalWeather AddLocalWeather(LocalWeather newLocalWeather);
        public LocalWeather AddLocalWeather(int cityCode, string cityName);

        public LocalWeather UpdateLocalWeather(string id, LocalWeather updatedLocalWeather);

        public LocalWeather DeleteLocalWeather(int citycode);
    }
}
