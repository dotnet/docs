using System;
using System.Globalization;

namespace conversions
{
    public static class StringToDateTime
    {
        public static void Examples()
        {
            FirstExample();
            GlobalExample();
            NoDefaultToCurrentDateTime();
            ParseExactExample();
        }

        static void FirstExample()
        {
            // <Snippet1>
            string dateInput = "Jan 1, 2009";
            var parsedDate = DateTime.Parse(dateInput);
            Console.WriteLine(parsedDate);
            // Displays the following output on a system whose culture is en-US:
            //       1/1/2009 00:00:00
            // </Snippet1>
        }

        static void GlobalExample()
        {
            // <Snippet2>
            var cultureInfo = new CultureInfo("de-DE");
            string dateString = "12 Juni 2008";
            var dateTime = DateTime.Parse(dateString, cultureInfo);
            Console.WriteLine(dateTime);
            // The example displays the following output:
            //       6/12/2008 00:00:00
            // </Snippet2>
        }

        static void NoDefaultToCurrentDateTime()
        {
            // <Snippet3>
            var cultureInfo = new CultureInfo("de-DE");
            string dateString = "12 Juni 2008";
            var dateTime = DateTime.Parse(dateString, cultureInfo,
                                            DateTimeStyles.NoCurrentDateDefault);
            Console.WriteLine(dateTime);
            // The example displays the following output if the current culture is en-US:
            //      6/12/2008 00:00:00
            // </Snippet3>
        }

        static void ParseExactExample()
        {
            // <Snippet4>
            var cultureInfo = new CultureInfo("en-US");
            string[] dateStrings = { " Friday, April 10, 2009", "Friday, April 10, 2009" };
            foreach (string dateString in dateStrings)
            {
                try
                {
                    var dateTime = DateTime.ParseExact(dateString, "D", cultureInfo);
                    Console.WriteLine(dateTime);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{dateString}'");
                }
            }
            // The example displays the following output:
            //       Unable to parse ' Friday, April 10, 2009'
            //       4/10/2009 00:00:00
            // </Snippet4>
        }
    }
}