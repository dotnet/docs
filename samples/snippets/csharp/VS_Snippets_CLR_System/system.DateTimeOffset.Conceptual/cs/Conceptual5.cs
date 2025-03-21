// <Snippet5>
using System;

public class TimeZoneAwareArithmetic
{
    public static void Main()
    {
        const string tzName = "Central Standard Time";

        DateTime generalTime = new DateTime(2008, 3, 9, 1, 30, 0);
        TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById(tzName);
        TimeSpan twoAndAHalfHours = new TimeSpan(2, 30, 0);

        // Instantiate DateTimeOffset value to have correct CST offset
        try
        {
            DateTimeOffset centralTime1 = new DateTimeOffset(generalTime,
                                          cst.GetUtcOffset(generalTime));

            // Add two and a half hours
            DateTimeOffset utcTime = centralTime1.ToUniversalTime();
            utcTime += twoAndAHalfHours;

            DateTimeOffset centralTime2 = TimeZoneInfo.ConvertTime(utcTime, cst);
            // Display result
            Console.WriteLine("{0} + {1} hours = {2}", centralTime1,
                                                       twoAndAHalfHours.ToString(),
                                                       centralTime2);
        }
        catch (TimeZoneNotFoundException)
        {
            Console.WriteLine("Unable to retrieve Central Standard Time zone information.");
        }
    }
}
// The example displays the following output to the console:
//    3/9/2008 1:30:00 AM -06:00 + 02:30:00 hours = 3/9/2008 5:00:00 AM -05:00
// </Snippet5>
