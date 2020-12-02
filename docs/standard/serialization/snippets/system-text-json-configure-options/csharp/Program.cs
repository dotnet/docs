using System;
using System.Diagnostics;
using System.Text.Json;

namespace OptionsPerfDemo
{
    public record Forecast(DateTime Date, int TemperatureC, string Summary);

    public class Program
    {
        public static void Main()
        {
            Forecast forecast = new(DateTime.Now, 40, "Hot");
            JsonSerializerOptions options = new() { WriteIndented = true };
            int iterations = 100000;

            var watch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                Serialize(forecast, options);
            }
            watch.Stop();
            Console.WriteLine($"Elapsed time using one options instance: {watch.ElapsedMilliseconds}");

            watch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                Serialize(forecast, null);
            }
            watch.Stop();
            Console.WriteLine($"Elapsed time creating new options instances: {watch.ElapsedMilliseconds}");
        }

        private static void Serialize(Forecast forecast, JsonSerializerOptions options)
        {
            if (options == null)
            {
                options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };
            }

            string forecastJson = JsonSerializer.Serialize<Forecast>(forecast, options);
        }
    }
}

// Produces output like the following example:
//
//Elapsed time using one options instance: 186
//Elapsed time creating new options instances: 52810