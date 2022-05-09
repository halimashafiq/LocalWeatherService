using LocalWeatherLibrary.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LocalWeatherLibrary.Data
{
    public class LocalWeatherService:ILocalWeatherService
    {
        private readonly IMongoCollection<LocalWeather> _LocalWeatherCollection;

        public LocalWeatherService(
            IOptions<LocalWeatherDatabaseSettings> LocalWeatherDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                LocalWeatherDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                LocalWeatherDatabaseSettings.Value.DatabaseName);

            _LocalWeatherCollection = mongoDatabase.GetCollection<LocalWeather>(
                LocalWeatherDatabaseSettings.Value.LocalWeatherCollectionName);
        }

        public List<LocalWeather> GetLocalWhether() =>
             _LocalWeatherCollection.Find(_ => true).ToList();


        public  LocalWeather GetByCityCode(int citycode) =>
             _LocalWeatherCollection.Find(x => x.CityCode == citycode).FirstOrDefault();

        public LocalWeather AddLocalWeather(LocalWeather newLocalWeather)
        {
            _LocalWeatherCollection.InsertOne(newLocalWeather);
            LocalWeather lw = _LocalWeatherCollection.Find(x => x.CityCode == newLocalWeather.CityCode).FirstOrDefault();
            return lw;
        }
        public LocalWeather AddLocalWeather(int cityCode, string cityName)
        {
            LocalWeather newLocalWeather = new LocalWeather();
            newLocalWeather.CityCode = cityCode;
            newLocalWeather.CityName = cityName; 
            _LocalWeatherCollection.InsertOne(newLocalWeather);
            LocalWeather lw = _LocalWeatherCollection.Find(x => x.CityCode == newLocalWeather.CityCode).FirstOrDefault();
            return lw;
        }

        public LocalWeather UpdateLocalWeather(string id, LocalWeather updatedLocalWeather)
        {
            _LocalWeatherCollection.ReplaceOne(x => x.Id == id, updatedLocalWeather);
            LocalWeather lw = _LocalWeatherCollection.Find(x => x.CityCode == updatedLocalWeather.CityCode).FirstOrDefault();
            return lw;
        }
        public LocalWeather DeleteLocalWeather(int citycode)
        {
            LocalWeather lw = _LocalWeatherCollection.Find(x => x.CityCode == citycode).FirstOrDefault();
            _LocalWeatherCollection.DeleteOne(x => x.CityCode == citycode);
            return lw;
        }
    }
}
