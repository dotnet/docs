using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class RoundtripEnumUsingSourceGeneration
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithPrecipEnum weatherForecast =
                WeatherForecastFactories.CreateWeatherForecastWithPrecipEnum();
            weatherForecast.DisplayPropertyValues();

            // <Serialize>
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                TypeInfoResolver = Context1.Default,
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </Serialize>
            Console.WriteLine($"JSON with enum as string:\n{jsonString}\n");

            weatherForecast.DisplayPropertyValues();
        }
    }

    // <Context1>
    [JsonSerializable(typeof(Precipitation))]
    [JsonSerializable(typeof(WeatherForecastWithPrecipEnum))]
    public partial class Context1 : JsonSerializerContext { }
    // </Context1>

    // <Context2>
    [JsonSourceGenerationOptions(UseStringEnumConverter = true)]
    [JsonSerializable(typeof(Precipitation2))]
    [JsonSerializable(typeof(WeatherForecast2WithPrecipEnum))]
    public partial class Context2 : JsonSerializerContext { }
    // </Context2>

    public class RoundtripEnumUsingSourceGeneration2
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecast2WithPrecipEnum weatherForecast =
                WeatherForecastFactories.CreateWeatherForecast2WithPrecipEnum();
            weatherForecast.DisplayPropertyValues();

            // <Serialize2>
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                TypeInfoResolver = Context2.Default,
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </Serialize2>
            Console.WriteLine($"JSON with enum as string:\n{jsonString}\n");

            weatherForecast.DisplayPropertyValues();
        }
    }
}
