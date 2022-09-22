using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class SerializeExcludePropertiesByAttribute
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithIgnoreAttribute weatherForecast =
                WeatherForecastFactories.CreateWeatherForecastWithIgnoreAttribute();
            weatherForecast.DisplayPropertyValues();

            // <Serialize>
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </Serialize>
            Console.WriteLine(jsonString);
            Console.WriteLine();
        }
    }
}
