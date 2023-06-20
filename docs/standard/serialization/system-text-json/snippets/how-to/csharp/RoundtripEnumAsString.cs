using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class RoundtripEnumAsString
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithEnum weatherForecast =
                WeatherForecastFactories.CreateWeatherForecastWithEnum();
            weatherForecast.DisplayPropertyValues();

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            Console.WriteLine($"JSON with enum as number:\n{jsonString}\n");

            // <Serialize>
            options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </Serialize>
            Console.WriteLine($"JSON with enum as string:\n{jsonString}\n");

            // <Deserialize>
            options = new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithEnum>(jsonString, options)!;
            // </Deserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
