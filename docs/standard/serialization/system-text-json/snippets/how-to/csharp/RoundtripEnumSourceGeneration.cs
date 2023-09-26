using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class RoundtripEnumUsingSourceGeneration
    {
        public static void Run()
        {
            // <Serialize>
            var weatherForecast = new WeatherForecastWithPrecipEnum
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Precipitation = Precipitation.Sleet
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                TypeInfoResolver = Context1.Default,
            };
            string? jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </Serialize>
            Console.WriteLine($"JSON with enum as string:\n{jsonString}\n");

            weatherForecast.DisplayPropertyValues();
        }
    }

    // <Context1>
    [JsonSerializable(typeof(WeatherForecastWithPrecipEnum))]
    public partial class Context1 : JsonSerializerContext { }
    // </Context1>

    // <Context2>
    [JsonSourceGenerationOptions(UseStringEnumConverter = true)]
    [JsonSerializable(typeof(WeatherForecast2WithPrecipEnum))]
    public partial class Context2 : JsonSerializerContext { }
    // </Context2>

    public class RoundtripEnumUsingSourceGeneration2
    {
        public static void Run()
        {
            // <Serialize>
            var weatherForecast = new WeatherForecast2WithPrecipEnum
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Precipitation = Precipitation2.Sleet
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                TypeInfoResolver = Context2.Default,
            };
            string? jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </Serialize2>
            Console.WriteLine($"JSON with enum as string:\n{jsonString}\n");

            weatherForecast.DisplayPropertyValues();
        }
    }
}
