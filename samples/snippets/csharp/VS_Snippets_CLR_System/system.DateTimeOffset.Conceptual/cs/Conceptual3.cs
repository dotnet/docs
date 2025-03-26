// <Snippet3>
using System;

public enum TimeComparison
{
    EarlierThan = -1,
    TheSameAs = 0,
    LaterThan = 1
}

public class DateTimeOffsetManipulation
{
    public static void Main()
    {
        DateTimeOffset localTime = DateTimeOffset.Now;
        DateTimeOffset utcTime = DateTimeOffset.UtcNow;

        Console.WriteLine($"Difference between local time and UTC: {(localTime - utcTime).Hours}:{(localTime - utcTime).Minutes:D2} hours");
        Console.WriteLine($"The local time is {Enum.GetName(typeof(TimeComparison), localTime.CompareTo(utcTime))} UTC.");
    }
}
// Regardless of the local time zone, the example displays
// the following output to the console:
//    Difference between local time and UTC: 0:00 hours.
//    The local time is TheSameAs UTC.
// </Snippet3>
