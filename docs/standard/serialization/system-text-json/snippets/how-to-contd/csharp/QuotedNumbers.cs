using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuotedNumbers
{
    public class Forecast
    {
        public DateTime Date { get; init; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
    };

    public class Program
    {
        public static void Main()
        {
            Forecast forecast = new()
            {
                Date = DateTime.Now,
                TemperatureC = 40,
                Summary = "Hot"
            };

            JsonSerializerOptions options = new()
            {
                NumberHandling =
                    JsonNumberHandling.AllowReadingFromString |
                    JsonNumberHandling.WriteAsString,
                WriteIndented = true
            };

            string forecastJson =
                JsonSerializer.Serialize<Forecast>(forecast, options);

            Console.WriteLine($"Output JSON:\n{forecastJson}");

            Forecast forecastDeserialized =
                JsonSerializer.Deserialize<Forecast>(forecastJson, options)!;

            Console.WriteLine($"Date: {forecastDeserialized.Date}");
            Console.WriteLine($"TemperatureC: {forecastDeserialized.TemperatureC}");
            Console.WriteLine($"Summary: {forecastDeserialized.Summary}");
        }
    }
}

// Produces output like the following example:
//
//Output JSON:
//{
//  "Date": "2020-10-23T12:27:06.4017385-07:00",
//  "TemperatureC": "40",
//  "Summary": "Hot"
//}
//Date: 10/23/2020 12:27:06 PM
//TemperatureC: 40
//Summary: Hot
