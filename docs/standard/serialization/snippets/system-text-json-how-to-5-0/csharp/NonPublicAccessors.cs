
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NonPublicAccessors
{
    public class Forecast
    {
        public DateTime Date { get; init; }
        [JsonInclude]
        public int TemperatureC { get; private set; }
        [JsonInclude]
        public string Summary { private get; set; }

        public Forecast()
        {
        }

        public Forecast (DateTime date, int temperatureC, string summary)
        {
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
        }
    };

    public class Program
    {
        public static void Main()
        {
            Forecast forecast = new(DateTime.Now, 40, "Hot");

            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };

            string forecastJson = JsonSerializer.Serialize<Forecast>(forecast, options);
            Console.WriteLine($"Output JSON:\n{forecastJson}");

            Forecast forecastDeserialized = JsonSerializer.Deserialize<Forecast>(forecastJson, options);
            Console.WriteLine($"Date: {forecastDeserialized.Date}");
            Console.WriteLine($"TemperatureC: {forecastDeserialized.TemperatureC}");
        }
    }
}

// Produces output like the following example:
//
//Output JSON:
//{
//  "Date": "2020-10-21T15:40:06.8956296-07:00",
//  "TemperatureC": 40,
//  "Summary": "Hot"
//}
//Date: 10 / 21 / 2020 3:40:06 PM
//TemperatureC: 40
