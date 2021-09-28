using System;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class DeserializeCaseInsensitive
    {
        public static void Run()
        {
            string jsonString =
@"{
  ""date"": ""2019-08-01T00:00:00-07:00"",
  ""temperatureCelsius"": 25,
  ""summary"": ""Hot""
}";
            Console.WriteLine($"JSON input:\n{jsonString}\n");

            // <Deserialize>
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString, options);
            // </Deserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
