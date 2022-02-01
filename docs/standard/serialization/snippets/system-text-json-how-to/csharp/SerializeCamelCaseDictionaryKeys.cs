using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class SerializeCamelCaseDictionaryKeys
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithDictionary weatherForecast = WeatherForecastFactories.CreateWeatherForecastWithDictionary();
            weatherForecast.DisplayPropertyValues();

            // <Serialize>
            var options = new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </Serialize>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <Deserialize>
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithDictionary>(jsonString)!;
            // </Deserialize>
            weatherForecast!.DisplayPropertyValues();
        }
    }
}
