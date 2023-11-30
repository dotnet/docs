using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class SerializeExcludeReadOnlyProperties
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithROProperty weatherForecast =
                WeatherForecastFactories.CreateWeatherForecastWithROProperty();
            weatherForecast.DisplayPropertyValues();

            // <Serialize>
            var options = new JsonSerializerOptions
            {
                IgnoreReadOnlyProperties = true,
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </Serialize>
            Console.WriteLine(jsonString);
            Console.WriteLine();
        }
    }
}
