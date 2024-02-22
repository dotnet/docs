using System.Text.Json;
using System.Text.Json.Nodes;

namespace Utf8ReaderToJsonNode
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(weatherForecast);

            var utf8Reader = new Utf8JsonReader(jsonUtf8Bytes);
            JsonNode? node = JsonNode.Parse(ref utf8Reader);
            Console.WriteLine(node);
        }
    }
}
