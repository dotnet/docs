using System.Text.Json;

namespace CopyOptions
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
                WriteIndented = true
            };

            JsonSerializerOptions optionsCopy = new(options);
            string forecastJson =
                JsonSerializer.Serialize<Forecast>(forecast, optionsCopy);

            Console.WriteLine($"Output JSON:\n{forecastJson}");
        }
    }
}

// Produces output like the following example:
//
//Output JSON:
//{
//  "Date": "2020-10-21T15:40:06.8998502-07:00",
//  "TemperatureC": 40,
//  "Summary": "Hot"
//}
