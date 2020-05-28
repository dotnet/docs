using System;
using System.Text.Json;

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
            var weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithDefault>(jsonString);
            weatherForecast.DisplayPropertyValues();

            // <SnippetDeserialize>
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true
            };
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithDefault>(jsonString, options);
            // </SnippetDeserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
