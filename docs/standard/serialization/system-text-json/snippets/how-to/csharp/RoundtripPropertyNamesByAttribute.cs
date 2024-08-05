using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripPropertyNamesByAttribute
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithPropertyName weatherForecast =
                WeatherForecastFactories.CreateWeatherForecastWithPropertyName();
            weatherForecast.DisplayPropertyValues();

            // <Serialize>
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions);
            // </Serialize>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <Deserialize>
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithPropertyName>(jsonString)!;
            weatherForecast.DisplayPropertyValues();
            // </Deserialize>
        }
    }
}
