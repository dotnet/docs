using System;

namespace SystemDateTimeReference
{
    public static class StringFormat
    {
        public static void Snippets()
        {
            ShowDefaultToString();
            ShowCultureSpecificToString();
            ShowDefaultFullDateAndTime();
            ShowCultureSpecificFullDateAndTime();
            ShowIso8601Format();
        }

        private static void ShowDefaultToString()
        {
            // <Snippet1>
            var date1 = new DateTime(2008, 3, 1, 7, 0, 0);
            Console.WriteLine(date1.ToString());
            // For en-US culture, displays 3/1/2008 7:00:00 AM
            // </Snippet1>
        }

        private static void ShowCultureSpecificToString()
        {
            // <Snippet2>
            var date1 = new DateTime(2008, 3, 1, 7, 0, 0);
            Console.WriteLine(date1.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")));
            // Displays 01/03/2008 07:00:00
            // </Snippet2>
        }

        private static void ShowDefaultFullDateAndTime()
        {
            // <Snippet3>
            var date1 = new DateTime(2008, 3, 1, 7, 0, 0);
            Console.WriteLine(date1.ToString("F"));
            // Displays Saturday, March 01, 2008 7:00:00 AM
            // </Snippet3>
        }

        private static void ShowCultureSpecificFullDateAndTime()
        {
            // <Snippet4>
            var date1 = new DateTime(2008, 3, 1, 7, 0, 0);
            Console.WriteLine(date1.ToString("F", new System.Globalization.CultureInfo("fr-FR")));
            // Displays samedi 1 mars 2008 07:00:00
            // </Snippet4>
        }

        private static void ShowIso8601Format()
        {
            // <Snippet5>
            var date1 = new DateTime(2008, 3, 1, 7, 0, 0, DateTimeKind.Utc);
            Console.WriteLine(date1.ToString("yyyy-MM-ddTHH:mm:sszzz", System.Globalization.CultureInfo.InvariantCulture));
            // Displays 2008-03-01T07:00:00+00:00
            // </Snippet5>
        }
    }
}
