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
        public string? Summary { private get; set; }
    };

    public class Program
    {
        public static void Run()
        {
            string json = """
                {
                    "Date":"2020-10-23T09:51:03.8702889-07:00",
                    "TemperatureC":40,
                    "Summary":"Hot"
                }
                """;
            Console.WriteLine($"Input JSON: {json}");

            Forecast forecastDeserialized = JsonSerializer.Deserialize<Forecast>(json)!;
            Console.WriteLine($"Date: {forecastDeserialized.Date}");
            Console.WriteLine($"TemperatureC: {forecastDeserialized.TemperatureC}");

            json = JsonSerializer.Serialize<Forecast>(forecastDeserialized);
            Console.WriteLine($"Output JSON: {json}");
        }
    }
}

// Produces output like the following example:
//
//Input JSON: { "Date":"2020-10-23T09:51:03.8702889-07:00","TemperatureC":40,"Summary":"Hot"}
//Date: 10 / 23 / 2020 9:51:03 AM
//TemperatureC: 40
//Output JSON: { "Date":"2020-10-23T09:51:03.8702889-07:00","TemperatureC":40,"Summary":"Hot"}
