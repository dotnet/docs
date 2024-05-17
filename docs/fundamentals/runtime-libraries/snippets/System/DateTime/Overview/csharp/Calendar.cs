using System;

namespace SystemDateTimeReference
{
    public static class CalendarSamples
    {
        public static void Snippets()
        {
            ThaiBuddistEra();
            ThaiBuddhistEraParse();
            InstantiateCalendar();
            CalendarFields();
            CalculateWeeks();
        }

        private static void ThaiBuddistEra()
        {
            // <Snippet1>
            var thTH = new System.Globalization.CultureInfo("th-TH");
            var value = new DateTime(2016, 5, 28);

            Console.WriteLine(value.ToString(thTH));

            thTH.DateTimeFormat.Calendar = new System.Globalization.GregorianCalendar();
            Console.WriteLine(value.ToString(thTH));
            // The example displays the following output:
            //       28/5/2559 0:00:00
            //       28/5/2016 0:00:00
            // </Snippet1>
        }

        private static void ThaiBuddhistEraParse()
        {
            // <Snippet2>
            var thTH = new System.Globalization.CultureInfo("th-TH");
            var value = DateTime.Parse("28/05/2559", thTH);
            Console.WriteLine(value.ToString(thTH));

            thTH.DateTimeFormat.Calendar = new System.Globalization.GregorianCalendar();
            Console.WriteLine(value.ToString(thTH));
            // The example displays the following output:
            //       28/5/2559 0:00:00
            //       28/5/2016 0:00:00
            // </Snippet2>
        }

        private static void InstantiateCalendar()
        {
            // <Snippet3>
            var thTH = new System.Globalization.CultureInfo("th-TH");
            var dat = new DateTime(2559, 5, 28, thTH.DateTimeFormat.Calendar);
            Console.WriteLine($"Thai Buddhist era date: {dat.ToString("d", thTH)}");
            Console.WriteLine($"Gregorian date:   {dat:d}");
            // The example displays the following output:
            //       Thai Buddhist Era Date:  28/5/2559
            //       Gregorian Date:     28/05/2016
            // </Snippet3>
        }

        private static void CalendarFields()
        {
            // <Snippet4>
            var thTH = new System.Globalization.CultureInfo("th-TH");
            var cal = thTH.DateTimeFormat.Calendar;
            var dat = new DateTime(2559, 5, 28, cal);
            Console.WriteLine("Using the Thai Buddhist Era calendar:");
            Console.WriteLine($"Date: {dat.ToString("d", thTH)}");
            Console.WriteLine($"Year: {cal.GetYear(dat)}");
            Console.WriteLine($"Leap year: {cal.IsLeapYear(cal.GetYear(dat))}\n");

            Console.WriteLine("Using the Gregorian calendar:");
            Console.WriteLine($"Date: {dat:d}");
            Console.WriteLine($"Year: {dat.Year}");
            Console.WriteLine($"Leap year: {DateTime.IsLeapYear(dat.Year)}");
            // The example displays the following output:
            //       Using the Thai Buddhist Era calendar
            //       Date :   28/5/2559
            //       Year: 2559
            //       Leap year :   True
            //
            //       Using the Gregorian calendar
            //       Date :   28/05/2016
            //       Year: 2016
            //       Leap year :   True
            // </Snippet4>
        }

        private static void CalculateWeeks()
        {
            // <Snippet5>
            var thTH = new System.Globalization.CultureInfo("th-TH");
            var thCalendar = thTH.DateTimeFormat.Calendar;
            var dat = new DateTime(1395, 8, 18, thCalendar);
            Console.WriteLine("Using the Thai Buddhist Era calendar:");
            Console.WriteLine($"Date: {dat.ToString("d", thTH)}");
            Console.WriteLine($"Day of Week: {thCalendar.GetDayOfWeek(dat)}");
            Console.WriteLine($"Week of year: {thCalendar.GetWeekOfYear(dat, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday)}\n");

            var greg = new System.Globalization.GregorianCalendar();
            Console.WriteLine("Using the Gregorian calendar:");
            Console.WriteLine($"Date: {dat:d}");
            Console.WriteLine($"Day of Week: {dat.DayOfWeek}");
            Console.WriteLine($"Week of year: {greg.GetWeekOfYear(dat, System.Globalization.CalendarWeekRule.FirstDay,DayOfWeek.Sunday)}");
            // The example displays the following output:
            //       Using the Thai Buddhist Era calendar
            //       Date :  18/8/1395
            //       Day of Week: Sunday
            //       Week of year: 34
            //
            //       Using the Gregorian calendar
            //       Date :  18/08/0852
            //       Day of Week: Sunday
            //       Week of year: 34
            // </Snippet5>
        }
    }
}
