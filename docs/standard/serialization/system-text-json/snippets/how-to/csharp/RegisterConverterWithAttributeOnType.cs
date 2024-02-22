using System.Text.Json;

namespace SystemTextJsonSamples
{
    class RegisterConverterWithAttributeOnType
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithTemperatureStruct weatherForecast =
                WeatherForecastFactories.CreateWeatherForecastWithTemperatureStruct();
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
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithTemperatureStruct>(jsonString)!;
            weatherForecast.DisplayPropertyValues();
            // </Deserialize>
        }
    }
}
