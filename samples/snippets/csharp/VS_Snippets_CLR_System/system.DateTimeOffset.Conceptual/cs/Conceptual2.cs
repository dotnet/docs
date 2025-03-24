// <Snippet2>
using System;

public enum TimeComparison2
{
    EarlierThan = -1,
    TheSameAs = 0,
    LaterThan = 1
}

public class DateManipulation
{
    public static void Main()
    {
        DateTime localTime = DateTime.Now;
        DateTime utcTime = DateTime.UtcNow;

        Console.WriteLine($"Difference between {localTime.Kind} and {utcTime.Kind} time: {(localTime - utcTime).Hours}:{(localTime - utcTime).Minutes} hours");
        Console.WriteLine($"The {localTime.Kind} time is {Enum.GetName(typeof(TimeComparison2), localTime.CompareTo(utcTime))} the {utcTime.Kind} time.");
    }
}
// If run in the U.S. Pacific Standard Time zone, the example displays
// the following output to the console:
//    Difference between Local and Utc time: -7:0 hours
//    The Local time is EarlierThan the Utc time.
// </Snippet2>
