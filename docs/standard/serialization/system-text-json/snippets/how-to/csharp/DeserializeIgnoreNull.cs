using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class DeserializeIgnoreNull
    {
        public static void Run()
        {
            string jsonString =
@"{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""TemperatureCelsius"": 25,
  ""Summary"": null
}";
            Console.WriteLine($"JSON input:\n{jsonString}\n");

            // Deserialize default behavior
            var weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithDefault>(jsonString)!;
            weatherForecast.DisplayPropertyValues();

            // <Deserialize>
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithDefault>(jsonString, options)!;
            // </Deserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
