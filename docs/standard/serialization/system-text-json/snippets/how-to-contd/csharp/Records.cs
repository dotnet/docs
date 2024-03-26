using System.Text.Json;

namespace Records
{
    public record Forecast(DateTime Date, int TemperatureC)
    {
        public string? Summary { get; init; }
    };

    public class Program
    {
        public static void Main()
        {
            Forecast forecast = new(DateTime.Now, 40)
            {
                Summary = "Hot!"
            };

            string forecastJson = JsonSerializer.Serialize<Forecast>(forecast);
            Console.WriteLine(forecastJson);
            Forecast? forecastObj = JsonSerializer.Deserialize<Forecast>(forecastJson);
            Console.WriteLine(forecastObj);
        }
    }
}

// Produces output like the following example:
//
//{ "Date":"2020-10-21T15:26:10.5044594-07:00","TemperatureC":40,"Summary":"Hot!"}
//Forecast { Date = 10 / 21 / 2020 3:26:10 PM, TemperatureC = 40, Summary = Hot! }
