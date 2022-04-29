using LocalWeatherAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LocalWeatherAPI.Services
{
    public class LocalWeatherService
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
        public void UpdateLocalWeather(string id, LocalWeather updatedLocalWeather) =>
             _LocalWeatherCollection.ReplaceOneAsync(x => x.Id == id, updatedLocalWeather);

        public async Task<List<LocalWeather>> GetAsync() =>
            await _LocalWeatherCollection.Find(_ => true).ToListAsync();

        public async Task<LocalWeather?> GetAsync(int citycode) =>
            await _LocalWeatherCollection.Find(x => x.CityCode == citycode).FirstOrDefaultAsync();

        public async Task CreateAsync(LocalWeather newLocalWeather) =>
            await _LocalWeatherCollection.InsertOneAsync(newLocalWeather);

        public async Task UpdateAsync(string id, LocalWeather updatedLocalWeather) =>
            await _LocalWeatherCollection.ReplaceOneAsync(x => x.Id == id, updatedLocalWeather);

        public async Task RemoveAsync(int citycode) =>
            await _LocalWeatherCollection.DeleteOneAsync(x => x.CityCode == citycode);
    }
}
