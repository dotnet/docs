using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class SerializeEnumCustomName
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithEnumCustomName weatherForecast =
                WeatherForecastFactories.CreateWeatherForecastWithEnumCustomName();
            weatherForecast.DisplayPropertyValues();

            // <Serialize>
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </Serialize>
            Console.WriteLine($"JSON with enum member with custom name:\n{jsonString}\n");
        }
    }
}
