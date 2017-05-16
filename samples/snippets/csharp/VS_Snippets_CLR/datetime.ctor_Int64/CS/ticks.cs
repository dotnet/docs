//<snippet1>
// This example demonstrates the DateTime(Int64) constructor.
using System;
using System.Globalization;

class Sample 
{
    public static void Main() 
    {
// Instead of using the implicit, default "G" date and time format string, we 
// use a custom format string that aligns the results and inserts leading zeroes.
    string format = "{0}) The {1} date and time is {2:MM/dd/yyyy hh:mm:ss tt}";

// Create a DateTime for the maximum date and time using ticks.
    DateTime dt1 = new DateTime(DateTime.MaxValue.Ticks);

// Create a DateTime for the minimum date and time using ticks.
    DateTime dt2 = new DateTime(DateTime.MinValue.Ticks);

// Create a custom DateTime for 7/28/1979 at 10:35:05 PM using a 
// calendar based on the "en-US" culture, and ticks. 
    long ticks = new DateTime(1979, 07, 28, 22, 35, 5, 
	new CultureInfo("en-US", false).Calendar).Ticks;
    DateTime dt3 = new DateTime(ticks);

    Console.WriteLine(format, 1, "maximum", dt1);
    Console.WriteLine(format, 2, "minimum", dt2);
    Console.WriteLine(format, 3, "custom ", dt3);
    Console.WriteLine("\nThe custom date and time is created from {0:N0} ticks.", ticks);
    }
}
/*
This example produces the following results:

1) The maximum date and time is 12/31/9999 11:59:59 PM
2) The minimum date and time is 01/01/0001 12:00:00 AM
3) The custom  date and time is 07/28/1979 10:35:05 PM

The custom date and time is created from 624,376,461,050,000,000 ticks.

*/
//</snippet1>