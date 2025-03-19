// <Snippet18>
using System;
using System.Globalization;

public class Example1
{
    public static void Main()
    {
        string[] dateValues = { "30-12-2011", "12-30-2011",
                              "30-12-11", "12-30-11" };
        string pattern = "MM-dd-yy";
        DateTime parsedDate;

        foreach (var dateValue in dateValues)
        {
            if (DateTime.TryParseExact(dateValue, pattern, null,
                                      DateTimeStyles.None, out parsedDate))
                Console.WriteLine($"Converted '{dateValue}' to {parsedDate:d}.");
            else
                Console.WriteLine($"Unable to convert '{dateValue}' to a date and time.");
        }
    }
}
// The example displays the following output:
//    Unable to convert '30-12-2011' to a date and time.
//    Unable to convert '12-30-2011' to a date and time.
//    Unable to convert '30-12-11' to a date and time.
//    Converted '12-30-11' to 12/30/2011.
// </Snippet18>
