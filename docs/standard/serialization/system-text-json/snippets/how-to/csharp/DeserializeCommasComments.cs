using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class DeserializeCommasComments
    {
        public static void Run()
        {
            string jsonString =
                """
                {
                  "Date": "2019-08-01T00:00:00-07:00",
                  "TemperatureC": 25, // Fahrenheit 77
                  "Summary": "Hot", /* Zharko */
                  // Comments on
                  /* separate lines */
                }
                """;
            Console.WriteLine($"JSON input:\n{jsonString}\n");

            // <Deserialize>
            var options = new JsonSerializerOptions
            {
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,
            };
            WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(
                jsonString,
                options
                )!;
            // </Deserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
