using System;
using System.Globalization;

namespace ParsingDateTimeExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DateTime Parsing Examples ===");
            DateTimeParseExample();
            DateTimeParseGermanExample();
            DateTimeParseNoDefaultExample();
            DateTimeParseExactExample();
            
            Console.WriteLine("\n=== DateOnly Parsing Examples ===");
            DateOnlyParseExample();
            DateOnlyParseExactExample();
            
            Console.WriteLine("\n=== TimeOnly Parsing Examples ===");
            TimeOnlyParseExample();
            TimeOnlyParseExactExample();
        }

        //<datetime-parse>
        static void DateTimeParseExample()
        {
            // Parse common date and time formats using current culture
            var dateTime1 = DateTime.Parse("1/15/2025 3:30 PM");
            var dateTime2 = DateTime.Parse("January 15, 2025");
            var dateTime3 = DateTime.Parse("15:30:45");

            Console.WriteLine($"Parsed: {dateTime1}");
            Console.WriteLine($"Parsed: {dateTime2}");
            Console.WriteLine($"Parsed: {dateTime3}");

            // Parse with specific culture
            var germanDate = DateTime.Parse("15.01.2025", new CultureInfo("de-DE"));
            Console.WriteLine($"German date parsed: {germanDate}");
        }
        //</datetime-parse>

        //<datetime-parseexact>
        static void DateTimeParseExactExample()
        {
            // Parse exact format
            var exactDate = DateTime.ParseExact("2025-01-15T14:30:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            Console.WriteLine($"Exact parse: {exactDate}");

            // Parse with custom format
            var customDate = DateTime.ParseExact("15/Jan/2025 2:30 PM", "dd/MMM/yyyy h:mm tt", CultureInfo.InvariantCulture);
            Console.WriteLine($"Custom format: {customDate}");
        }
        //</datetime-parseexact>

        //<datetime_parse_culture>
        static void DateTimeParseGermanExample()
        {
            var cultureInfo = new CultureInfo("de-DE");
            string dateString = "12 Juni 2008";
            var dateTime = DateTime.Parse(dateString, cultureInfo);
            Console.WriteLine(dateTime);
            // The example displays the following output:
            //       6/12/2008 00:00:00
        }
        //</datetime_parse_culture>

        //<datetime-parse-nodefault>
        static void DateTimeParseNoDefaultExample()
        {
            var cultureInfo = new CultureInfo("de-DE");
            string dateString = "12 Juni 2008";
            var dateTime = DateTime.Parse(dateString, cultureInfo,
                                            DateTimeStyles.NoCurrentDateDefault);
            Console.WriteLine(dateTime);
            // The example displays the following output if the current culture is en-US:
            //      6/12/2008 00:00:00
        }
        //</datetime-parse-nodefault>

        //<dateonly-parse>
        static void DateOnlyParseExample()
        {
            // Parse common date formats
            var date1 = DateOnly.Parse("1/15/2025");
            var date2 = DateOnly.Parse("January 15, 2025", CultureInfo.InvariantCulture);
            var date3 = DateOnly.Parse("2025-01-15");

            Console.WriteLine($"Parsed date: {date1}");
            Console.WriteLine($"Parsed date: {date2.ToString("D")}"); // Long date format
            Console.WriteLine($"Parsed date: {date3.ToString("yyyy-MM-dd")}");

            // Parse with specific culture
            var germanDate = DateOnly.Parse("15.01.2025", new CultureInfo("de-DE"));
            Console.WriteLine($"German date: {germanDate}");
        }
        //</dateonly-parse>

        //<dateonly-parseexact>
        static void DateOnlyParseExactExample()
        {
            // Parse exact format
            var exactDate = DateOnly.ParseExact("21 Oct 2015", "dd MMM yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine($"Exact date: {exactDate}");

            // Parse ISO format
            var isoDate = DateOnly.ParseExact("2025-01-15", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Console.WriteLine($"ISO date: {isoDate}");

            // Parse with multiple possible formats
            string[] formats = { "MM/dd/yyyy", "M/d/yyyy", "dd/MM/yyyy" };
            var flexibleDate = DateOnly.ParseExact("1/15/2025", formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            Console.WriteLine($"Flexible parse: {flexibleDate}");
        }
        //</dateonly-parseexact>

        //<timeonly-parse>
        static void TimeOnlyParseExample()
        {
            // Parse common time formats
            var time1 = TimeOnly.Parse("14:30:15");
            var time2 = TimeOnly.Parse("2:30 PM", CultureInfo.InvariantCulture);
            var time3 = TimeOnly.Parse("17:45");

            Console.WriteLine($"Parsed time: {time1}");
            Console.WriteLine($"Parsed time: {time2.ToString("t")}"); // Short time format
            Console.WriteLine($"Parsed time: {time3.ToString("HH:mm")}");

            // Parse with milliseconds
            var preciseTime = TimeOnly.Parse("14:30:15.123");
            Console.WriteLine($"Precise time: {preciseTime.ToString("HH:mm:ss.fff")}");
        }
        //</timeonly-parse>

        //<timeonly-parseexact>
        static void TimeOnlyParseExactExample()
        {
            // Parse exact format
            var exactTime = TimeOnly.ParseExact("5:00 pm", "h:mm tt", CultureInfo.InvariantCulture);
            Console.WriteLine($"Exact time: {exactTime}");

            // Parse 24-hour format
            var militaryTime = TimeOnly.ParseExact("17:30:25", "HH:mm:ss", CultureInfo.InvariantCulture);
            Console.WriteLine($"Military time: {militaryTime}");

            // Parse with multiple possible formats
            string[] timeFormats = { "h:mm tt", "HH:mm", "H:mm" };
            var flexibleTime = TimeOnly.ParseExact("2:30 PM", timeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            Console.WriteLine($"Flexible time parse: {flexibleTime}");
        }
        //</timeonly-parseexact>
    }
}