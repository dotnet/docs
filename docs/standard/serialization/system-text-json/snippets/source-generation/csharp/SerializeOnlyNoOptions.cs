// <All>
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializeOnlyNoOptions
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
    }

    // <JsonSourceGenerationOptionsGenmode>
    [JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(WeatherForecast))]
    internal partial class SerializeOnlyContext : JsonSerializerContext
    {
    }
    // </JsonSourceGenerationOptionsGenmode>
    
    // <JsonSerializableGenmode>
    [JsonSerializable(typeof(WeatherForecast), GenerationMode = JsonSourceGenerationMode.Serialization)]
    internal partial class SerializeOnlyWeatherForecastOnlyContext : JsonSerializerContext
    {
    }
    // </JsonSerializableGenmode>

     public class Program
    {
        public static void Main()
        {
            string jsonString;
            WeatherForecast weatherForecast = new()
                { Date = DateTime.Parse("2019-08-01"), TemperatureCelsius = 25, Summary = "Hot" };

            // Use context that selects Serialization mode only for WeatherForecast.
            // <SerializeWFContext>
            jsonString = JsonSerializer.Serialize(weatherForecast,
                SerializeOnlyWeatherForecastOnlyContext.Default.WeatherForecast);
            // </SerializeWFContext> 
            Console.WriteLine(jsonString);
            // output:
            //{"Date":"2019-08-01T00:00:00","TemperatureCelsius":25,"Summary":"Hot"}

            // Use a context that selects Serialization mode.
            // <SerializeOnlyContext> 
            jsonString = JsonSerializer.Serialize(weatherForecast,
                SerializeOnlyContext.Default.WeatherForecast);
            // </SerializeOnlyContext> 
            Console.WriteLine(jsonString);
            // output:
            //{"Date":"2019-08-01T00:00:00","TemperatureCelsius":25,"Summary":"Hot"}
        }
    }
}
// </All>
