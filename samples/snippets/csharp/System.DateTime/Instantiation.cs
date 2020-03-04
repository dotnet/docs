using System;

namespace SystemDateTimeReference
{
    public static class Instantiation
    {
        public static void Snippets()
        {
            InstantiateWithConstructor();
            InstantiateWithReturnValue();
            InstantiateFromString();
            InstantiateUsingDftCtor();
        }

        private static void InstantiateWithConstructor()
        {
            // <Snippet1>
            var date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            Console.WriteLine(date1);
            // </Snippet1>
        }

        private static void InstantiateWithReturnValue()
        {
            // <Snippet3>
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.UtcNow;
            DateTime date3 = DateTime.Today;
            // </Snippet3>
        }

        private static void InstantiateFromString()
        {
            // <Snippet4>
            var dateString = "5/1/2008 8:30:52 AM";
            DateTime date1 = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);
            var iso8601String = "20080501T08:30:52Z";
            DateTime dateISO8602 = DateTime.ParseExact(iso8601String, "yyyyMMddTHH:mm:ssZ",
                                            System.Globalization.CultureInfo.InvariantCulture);
            // </Snippet4>
        }

        private static void InstantiateUsingDftCtor()
        {
            // <Snippet5>
            var dat1 = new DateTime();
            // The following method call displays 1/1/0001 12:00:00 AM.
            Console.WriteLine(dat1.ToString(System.Globalization.CultureInfo.InvariantCulture));
            // The following method call displays True.
            Console.WriteLine(dat1.Equals(DateTime.MinValue));
            // </Snippet5>
        }
    }
}
