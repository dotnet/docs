using System;
using Indexers;

namespace DateOnlyExample;

class Program
{
    static void Main()
    {
        var temperatureData = new DailyTemperatureData();

        // Store temperature data using DateOnly
        var today = DateOnly.FromDateTime(DateTime.Today);
        temperatureData[today] = (75.2, 62.1);
        temperatureData[today.AddDays(1)] = (78.5, 64.3);
        temperatureData[today.AddDays(-1)] = (72.8, 59.7);

        // Retrieve data using DateOnly
        Console.WriteLine($"Today's temperature: High {temperatureData[today].High}°F, Low {temperatureData[today].Low}°F");

        // Can also use DateTime - only the date part is used
        var tomorrow = DateTime.Today.AddDays(1);
        Console.WriteLine($"Tomorrow's temperature: High {temperatureData[tomorrow].High}°F, Low {temperatureData[tomorrow].Low}°F");

        // Show available dates
        Console.WriteLine("Available temperature data for:");
        foreach (var date in temperatureData.AvailableDates)
        {
            Console.WriteLine($"  {date:yyyy-MM-dd}");
        }
    }
}