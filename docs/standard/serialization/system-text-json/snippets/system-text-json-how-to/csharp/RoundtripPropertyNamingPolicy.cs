using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripPropertyNamingPolicy
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecast weatherForecast = WeatherForecastFactories.CreateWeatherForecast();
            weatherForecast.DisplayPropertyValues();

            // <Serialize>
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new UpperCaseNamingPolicy(),
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </Serialize>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <Deserialize>
            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new UpperCaseNamingPolicy()
            };
            weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString, options)!;
            // </Deserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
