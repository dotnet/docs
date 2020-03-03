// <Snippet1>
using System;
using System.Globalization;

class Sample 
{
    public static void Main() 
    {
        // Initialize a DateTime object.
        Console.WriteLine("Initialize the DateTime object to May 16, 2001 3:02:15 AM.\n");
        DateTime dateAndTime = new System.DateTime(2001, 5, 16, 3, 2, 15);

        // Display the name of the current culture.
        Console.WriteLine($"Current culture: \"{CultureInfo.CurrentCulture.Name}\"\n");
        var dtfi = CultureInfo.CurrentCulture.DateTimeFormat;

        // Display the long date pattern and string.
        Console.WriteLine($"Long date pattern: \"{dtfi.LongDatePattern}\"");
        Console.WriteLine($"Long date string:  \"{dateAndTime.ToLongDateString()}\"\n");

        // Display the long time pattern and string.
        Console.WriteLine($"Long time pattern: \"{dtfi.LongTimePattern}\"");
        Console.WriteLine($"Long time string:  \"{dateAndTime.ToLongTimeString()}\"\n");

        // Display the short date pattern and string.
        Console.WriteLine($"Short date pattern: \"{dtfi.ShortDatePattern}\"");
        Console.WriteLine($"Short date string:  \"{dateAndTime.ToShortDateString()}\"\n");

        // Display the short time pattern and string.
        Console.WriteLine($"Short time pattern: \"{dtfi.ShortTimePattern}\"");
        Console.WriteLine($"Short time string:  \"{dateAndTime.ToShortTimeString()}\"\n");
    }
}
// The example displays output similar to the following:
//        Current culture: "en-US"
//
//        Long date pattern: "dddd, MMMM d, yyyy"
//        Long date string:  "Wednesday, May 16, 2001"
//
//        Long time pattern: "h:mm:ss tt"
//        Long time string:  "3:02:15 AM"
//
//        Short date pattern: "M/d/yyyy"
//        Short date string:  "5/16/2001"
//
//        Short time pattern: "h:mm tt"
//        Short time string:  "3:02 AM"
//</snippet1>
