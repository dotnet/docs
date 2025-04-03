// <Snippet8>
using System;

public struct TimeZoneTime
{
    public TimeZoneInfo TimeZone;
    public DateTime Time;

    public TimeZoneTime(TimeZoneInfo tz, DateTime time)
    {
        ArgumentNullException.ThrowIfNull(tz);

        TimeZone = tz;
        Time = time;
    }

    public TimeZoneTime AddTime(TimeSpan interval)
    {
        // Convert time to UTC
        DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(Time, TimeZone);
        // Add time interval to time
        utcTime = utcTime.Add(interval);
        // Convert time back to time in time zone
        return new TimeZoneTime(TimeZone, TimeZoneInfo.ConvertTime(utcTime,
                                TimeZoneInfo.Utc, TimeZone));
    }
}

public class TimeArithmetic
{
    public const string TzName = "Central Standard Time";

    public static void Main()
    {
        try
        {
            TimeZoneTime cstTime1, cstTime2;

            TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById(TzName);
            DateTime time1 = new(2008, 3, 9, 1, 30, 0);
            TimeSpan twoAndAHalfHours = new(2, 30, 0);

            cstTime1 = new TimeZoneTime(cst, time1);
            cstTime2 = cstTime1.AddTime(twoAndAHalfHours);
            Console.WriteLine($"{cstTime1.Time} + {twoAndAHalfHours.ToString()} hours = {cstTime2.Time}");
        }
        catch
        {
            Console.WriteLine($"Unable to find {TzName}.");
        }
    }
}
// </Snippet8>
