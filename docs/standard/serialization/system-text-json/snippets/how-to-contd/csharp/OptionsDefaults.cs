using System.Text.Json;

namespace OptionsDefaults
{
    public class Forecast
    {
        public DateTime? Date { get; init; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
    };

    public class Program
    {
        public static void Run()
        {
            Forecast forecast = new()
            {
                Date = DateTime.Now,
                TemperatureC = 40,
                Summary = "Hot"
            };

            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                WriteIndented = true
            };

            Console.WriteLine(
                $"PropertyNameCaseInsensitive: {options.PropertyNameCaseInsensitive}");
            Console.WriteLine(
                $"JsonNamingPolicy: {options.PropertyNamingPolicy}");
            Console.WriteLine(
                $"NumberHandling: {options.NumberHandling}");

            string forecastJson = JsonSerializer.Serialize<Forecast>(forecast, options);
            Console.WriteLine($"Output JSON:\n{forecastJson}");

            Forecast? forecastDeserialized =
                JsonSerializer.Deserialize<Forecast>(forecastJson, options);

            Console.WriteLine($"Date: {forecastDeserialized?.Date}");
            Console.WriteLine($"TemperatureC: {forecastDeserialized?.TemperatureC}");
            Console.WriteLine($"Summary: {forecastDeserialized?.Summary}");
        }
    }
}

// Produces output like the following example:
//
//PropertyNameCaseInsensitive: True
//JsonNamingPolicy: System.Text.Json.JsonCamelCaseNamingPolicy
//NumberHandling: AllowReadingFromString
//Output JSON:
//{
//  "date": "2020-10-21T15:40:06.9040831-07:00",
//  "temperatureC": 40,
//  "summary": "Hot"
//}
//Date: 10 / 21 / 2020 3:40:06 PM
//TemperatureC: 40
//Summary: Hot
