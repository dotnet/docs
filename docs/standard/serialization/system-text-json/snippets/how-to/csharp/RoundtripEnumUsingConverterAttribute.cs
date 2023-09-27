using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class RoundtripEnumUsingConverterAttribute
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
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </Serialize>
            Console.WriteLine($"JSON with enum as string:\n{jsonString}\n");

            // <Deserialize>
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithPrecipEnum>(jsonString, options)!;
            // </Deserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
