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

        private static void FirstExample()
        {
            // <Snippet1>
            string dateInput = "Jan 1, 2009";
            DateTime parsedDate = DateTime.Parse(dateInput);
            Console.WriteLine(parsedDate);
            // Displays the following output on a system whose culture is en-US:
            //       1/1/2009 12:00:00 AM
            // </Snippet1>
        }
        private static void GlobalExample()
        {
            // <Snippet2>
            CultureInfo MyCultureInfo = new CultureInfo("de-DE");
            string MyString = "12 Juni 2008";
            DateTime MyDateTime = DateTime.Parse(MyString, MyCultureInfo);
            Console.WriteLine(MyDateTime);
            // The example displays the following output:
            //       6/12/2008 12:00:00 AM
            // </Snippet2>
        }

        private static void NoDefaultToCurrentDateTime()
        {
            // <Snippet3>
            CultureInfo MyCultureInfo = new CultureInfo("de-DE");
            string MyString = "12 Juni 2008";
            DateTime MyDateTime = DateTime.Parse(MyString, MyCultureInfo,
                                                 DateTimeStyles.NoCurrentDateDefault);
            Console.WriteLine(MyDateTime);
            // The example displays the following output if the current culture is en-US:
            //      6/12/2008 12:00:00 AM
            // </Snippet3>
        }

        static private void ParseExactExample()
        {
            // <Snippet4>
            CultureInfo MyCultureInfo = new CultureInfo("en-US");
            string[] MyString = { " Friday, April 10, 2009", "Friday, April 10, 2009" };
            foreach (string dateString in MyString)
            {
                try
                {
                    DateTime MyDateTime = DateTime.ParseExact(dateString, "D", MyCultureInfo);
                    Console.WriteLine(MyDateTime);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to parse '{0}'", dateString);
                }
            }
            // The example displays the following output:
            //       Unable to parse ' Friday, April 10, 2009'
            //       4/10/2009 12:00:00 AM
            // </Snippet4>
        }
    }
}