using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class ConvertInferredTypesToObject
    {
        public static void Run()
        {
            string jsonString;

            // Serialize to create input JSON
            var weatherForecast = WeatherForecastFactories.CreateWeatherForecast();
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            serializeOptions.WriteIndented = true;
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions);
            Console.WriteLine($"JSON input:\n{jsonString}\n");

            // Deserialize without converter
            // Properties are JsonElement type.
            WeatherForecastWithObjectProperties weatherForecastWithObjectProperties = JsonSerializer.Deserialize<WeatherForecastWithObjectProperties>(jsonString)!;
            weatherForecastWithObjectProperties.DisplayPropertyValues();

            // <Register>
            var deserializeOptions = new JsonSerializerOptions();
            deserializeOptions.Converters.Add(new ObjectToInferredTypesConverter());
            // </Register>
            weatherForecastWithObjectProperties = JsonSerializer.Deserialize<WeatherForecastWithObjectProperties>(jsonString, deserializeOptions)!;
            weatherForecastWithObjectProperties.DisplayPropertyValues();
        }
    }
}
