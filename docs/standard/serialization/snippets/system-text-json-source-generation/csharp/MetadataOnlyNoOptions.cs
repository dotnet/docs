// <All>
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MetadataOnlyNoOptions
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
    }

    // <JsonSerializableGenMode>
    [JsonSerializable(typeof(WeatherForecast), GenerationMode = JsonSourceGenerationMode.Metadata)]
    internal partial class MetadataOnlyWeatherForecastOnlyContext : JsonSerializerContext
    {
    }
    // </JsonSerializableGenMode>

    // <JsonSourceGenerationOptionsGenMode>
    [JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Metadata)]
    [JsonSerializable(typeof(WeatherForecast))]
    internal partial class MetadataOnlyContext : JsonSerializerContext
    {
    }
    // </JsonSourceGenerationOptionsGenMode>

    public class Program
    {
        public static void Main()
        {
            string jsonString =
 @"{
  ""Date"": ""2019-08-01T00:00:00"",
  ""TemperatureCelsius"": 25,
  ""Summary"": ""Hot""
}
";
            WeatherForecast? weatherForecast;

            // Deserialize with context that selects metadata mode only for WeatherForecast only.
            // <DeserializeWFContext> 
            weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(
                jsonString, MetadataOnlyWeatherForecastOnlyContext.Default.WeatherForecast);
            // </DeserializeWFContext> 
            Console.WriteLine($"Date={weatherForecast?.Date}");
            // output:
            //Date=8/1/2019 12:00:00 AM

            // Serialize with context that selects metadata mode only for WeatherForecast only.
            // <SerializeWFContext> 
            jsonString = JsonSerializer.Serialize(
                weatherForecast!,
                MetadataOnlyWeatherForecastOnlyContext.Default.WeatherForecast);
            // </SerializeWFContext> 
            Console.WriteLine(jsonString);
            // output:
            //{"Date":"2019-08-01T00:00:00","TemperatureCelsius":25,"Summary":"Hot"}

            // Deserialize with context that selects metadata mode only.
            // <DeserializeMetadataOnlyContext> 
            weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(
                jsonString, MetadataOnlyContext.Default.WeatherForecast);
            // </DeserializeMetadataOnlyContext> 
            Console.WriteLine($"Date={weatherForecast?.Date}");
            // output:
            //Date=8/1/2019 12:00:00 AM

            // Serialize with context that selects metadata mode only.
            // <SerializeMetadataOnlyContext>
            jsonString = JsonSerializer.Serialize(
                weatherForecast!, MetadataOnlyContext.Default.WeatherForecast);
            // </SerializeMetadataOnlyContext>
            Console.WriteLine(jsonString);
            // output:
            //{"Date":"2019-08-01T00:00:00","TemperatureCelsius":0,"Summary":"Hot"}
        }
    }
}
// </All>
