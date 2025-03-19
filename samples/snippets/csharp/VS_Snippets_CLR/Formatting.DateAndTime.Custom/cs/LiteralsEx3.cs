using System;
using System.Globalization;

public class Example6
{
    public static void Main()
    {
        // <Snippet22>
        string format = "dd MMM yyyy hh:mm tt \"pst\"";
        var dat = new DateTime(2016, 8, 18, 16, 50, 0);
        // Display the result string.
        Console.WriteLine(dat.ToString(format));

        // Parse a string.
        string value = "25 Dec 2016 12:00 pm pst";
        if (DateTime.TryParseExact(value, format, null,
                                   DateTimeStyles.None, out DateTime newDate))
            Console.WriteLine(newDate);
        else
            Console.WriteLine($"Unable to parse '{value}'");

        // The example displays the following output:
        //       18 Aug 2016 04:50 PM pst
        //       12/25/2016 12:00:00 PM
        // </Snippet22>
    }
}
