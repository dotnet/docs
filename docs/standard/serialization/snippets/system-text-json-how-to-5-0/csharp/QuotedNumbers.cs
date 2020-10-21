using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuotedNumbers
{
    public class Forecast
    {
        public DateTime Date { get; init; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
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

            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                NumberHandling = JsonNumberHandling.WriteAsString,
                WriteIndented = true
            };

            string forecastJson = JsonSerializer.Serialize<Forecast>(forecast, options);
            Console.WriteLine($"Output JSON:\n{forecastJson}");

            options = new(JsonSerializerDefaults.Web)
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };

            Forecast forecastDeserialized = JsonSerializer.Deserialize<Forecast>(forecastJson, options);
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
//  "date": "2020-10-21T15:40:06.9109159-07:00",
//  "temperatureC": "40",
//  "summary": "Hot"
//}
//Date: 10 / 21 / 2020 3:40:06 PM
//TemperatureC: 40
//Summary: Hot
