﻿using System;
using System.Globalization;

public class Example5
{
    public static void Main()
    {
        // <Snippet20>
        string[] formats = { "dd MMM yyyy hh:mm tt PST",
                           "dd MMM yyyy hh:mm tt PDT" };
        var dat = new DateTime(2016, 8, 18, 16, 50, 0);
        // Display the result string.
        Console.WriteLine(dat.ToString(formats[1]));

        // Parse a string.
        string value = "25 Dec 2016 12:00 pm PST";
        if (DateTime.TryParseExact(value, formats, null,
                                   DateTimeStyles.None, out DateTime newDate))
            Console.WriteLine(newDate);
        else
            Console.WriteLine($"Unable to parse '{value}'");

        // The example displays the following output:
        //       18 Aug 2016 04:50 PM PDT
        //       12/25/2016 12:00:00 PM
        // </Snippet20>
    }
}
