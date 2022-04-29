namespace LocalWeatherAPI.Models
{
    public class LocalWeatherDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string LocalWeatherCollectionName { get; set; } = null!;

    }
}
