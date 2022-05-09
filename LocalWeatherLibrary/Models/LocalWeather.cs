using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LocalWeatherLibrary.Models;

public class LocalWeather
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Code")]   
    public int CityCode { get; set; }

    [BsonElement("Name")]
    public string CityName { get; set; } = null!;
    public string Description { get; set; } = null!;

    public double Temperature { get; set; }
    public double Pressure { get; set; }
    public double Humidity { get; set; }
    public double WindSpeed { get; set; }
    public int WeatherDescription { get; set; }
}