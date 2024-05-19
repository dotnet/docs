using System;
using System.Collections.Generic;

namespace SystemDateTimeReference
{
    public static class Parsing
    {
        public static void Snippets()
        {
            ParseStandardFormats();
            ParseCustomFormats();
            ParseISO8601();
        }

        private static void ParseStandardFormats()
        {
            // <Snippet1>
            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");

            var date1 = new DateTime(2013, 6, 1, 12, 32, 30);
            var badFormats = new List<String>();

            Console.WriteLine($"{"Date String",-37} {"Date",-19}\n");
            foreach (var dateString in date1.GetDateTimeFormats())
            {
                DateTime parsedDate;
                if (DateTime.TryParse(dateString, out parsedDate))
                    Console.WriteLine($"{dateString,-37} {DateTime.Parse(dateString),-19}");
                else
                    badFormats.Add(dateString);
            }

            // Display strings that could not be parsed.
            if (badFormats.Count > 0)
            {
                Console.WriteLine("\nStrings that could not be parsed: ");
                foreach (var badFormat in badFormats)
                    Console.WriteLine($"   {badFormat}");
            }
            // Press "Run" to see the output.
            // </Snippet1>
        }

        private static void ParseCustomFormats()
        {
            // <Snippet2>
            string[] formats = { "yyyyMMdd", "HHmmss" };
            string[] dateStrings = { "20130816", "20131608", "  20130816   ",
                               "115216", "521116", "  115216  " };
            DateTime parsedDate;

            foreach (var dateString in dateStrings)
            {
                if (DateTime.TryParseExact(dateString, formats, null,
                                           System.Globalization.DateTimeStyles.AllowWhiteSpaces |
                                           System.Globalization.DateTimeStyles.AdjustToUniversal,
                                           out parsedDate))
                    Console.WriteLine($"{dateString} --> {parsedDate:g}");
                else
                    Console.WriteLine($"Cannot convert {dateString}");
            }
            // The example displays the following output:
            //       20130816 --> 8/16/2013 12:00 AM
            //       Cannot convert 20131608
            //         20130816    --> 8/16/2013 12:00 AM
            //       115216 --> 4/22/2013 11:52 AM
            //       Cannot convert 521116
            //         115216   --> 4/22/2013 11:52 AM
            // </Snippet2>
        }
        private static void ParseISO8601()
        {
            // <Snippet3>
            var iso8601String = "20080501T08:30:52Z";
            DateTime dateISO8602 = DateTime.ParseExact(iso8601String, "yyyyMMddTHH:mm:ssZ",
                System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine($"{iso8601String} --> {dateISO8602:g}");
            // </Snippet3>
        }
    }
}
