using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class SerializeExcludeNullValueProperties
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecast weatherForecast = WeatherForecastFactories.CreateWeatherForecast();
            weatherForecast.Summary = null;
            weatherForecast.DisplayPropertyValues();

            // <Serialize>
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </Serialize>
            Console.WriteLine(jsonString);
            Console.WriteLine();
        }
    }
}
