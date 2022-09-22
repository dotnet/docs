using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RegisterConverterWithAttributeOnProperty

    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithConverterAttribute weatherForecast = 
                WeatherForecastFactories.CreateWeatherForecastWithConverterAttribute();
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
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithConverterAttribute>(jsonString)!;
            // </Deserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
