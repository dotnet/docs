// <Snippet7>
using System;

public struct TimeZoneTime2
{
    public TimeZoneInfo TimeZone;
    public DateTimeOffset Time;

    public TimeZoneTime2(TimeZoneInfo tz, DateTimeOffset time)
    {
        ArgumentNullException.ThrowIfNull(tz);

        TimeZone = tz;
        Time = time;
    }

    public TimeZoneTime2 AddTime(TimeSpan interval)
    {
        // Convert time to UTC
        DateTimeOffset utcTime = TimeZoneInfo.ConvertTime(Time, TimeZoneInfo.Utc);
        // Add time interval to time
        utcTime = utcTime.Add(interval);
        // Convert time back to time in time zone
        return new TimeZoneTime2(TimeZone, TimeZoneInfo.ConvertTime(utcTime, TimeZone));
    }
}

public class TimeArithmetic2
{
    public const string tzName = "Central Standard Time";

    public static void Main()
    {
        try
        {
            TimeZoneTime2 cstTime1, cstTime2;

            TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById(tzName);
            DateTime time1 = new(2008, 3, 9, 1, 30, 0);
            TimeSpan twoAndAHalfHours = new(2, 30, 0);

            cstTime1 = new TimeZoneTime2(cst,
                           new DateTimeOffset(time1, cst.GetUtcOffset(time1)));
            cstTime2 = cstTime1.AddTime(twoAndAHalfHours);
            Console.WriteLine($"{cstTime1.Time} + {twoAndAHalfHours.ToString()} hours = {cstTime2.Time}");
        }
        catch
        {
            Console.WriteLine($"Unable to find {tzName}.");
        }
    }
}
// </Snippet7>

// <Snippet6>
// Define a structure for DateTime values for internal use only
internal struct TimeWithTimeZone
{
    TimeZoneInfo TimeZone;
    DateTime Time;
}
// </Snippet6>
