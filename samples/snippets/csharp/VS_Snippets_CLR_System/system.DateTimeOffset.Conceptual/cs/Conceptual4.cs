// <Snippet4>
using System;

public class IntervalArithmetic
{
    public static void Main()
    {
        DateTime generalTime = new DateTime(2008, 3, 9, 1, 30, 0);
        const string tzName = "Central Standard Time";
        TimeSpan twoAndAHalfHours = new TimeSpan(2, 30, 0);

        // Instantiate DateTimeOffset value to have correct CST offset
        try
        {
            DateTimeOffset centralTime1 = new DateTimeOffset(generalTime,
                       TimeZoneInfo.FindSystemTimeZoneById(tzName).GetUtcOffset(generalTime));

            // Add two and a half hours
            DateTimeOffset centralTime2 = centralTime1.Add(twoAndAHalfHours);
            // Display result
            Console.WriteLine($"{centralTime1} + {twoAndAHalfHours.ToString()} hours = {centralTime2}");
        }
        catch (TimeZoneNotFoundException)
        {
            Console.WriteLine("Unable to retrieve Central Standard Time zone information.");
        }
    }
}
// The example displays the following output to the console:
//    3/9/2008 1:30:00 AM -06:00 + 02:30:00 hours = 3/9/2008 4:00:00 AM -06:00
// </Snippet4>
