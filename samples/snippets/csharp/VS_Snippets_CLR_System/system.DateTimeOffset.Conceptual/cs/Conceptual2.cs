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

        Console.WriteLine("Difference between {0} and {1} time: {2}:{3} hours",
                          localTime.Kind,
                          utcTime.Kind,
                          (localTime - utcTime).Hours,
                          (localTime - utcTime).Minutes);
        Console.WriteLine("The {0} time is {1} the {2} time.",
                          localTime.Kind,
                          Enum.GetName(typeof(TimeComparison2), localTime.CompareTo(utcTime)),
                          utcTime.Kind);
    }
}
// If run in the U.S. Pacific Standard Time zone, the example displays
// the following output to the console:
//    Difference between Local and Utc time: -7:0 hours
//    The Local time is EarlierThan the Utc time.
// </Snippet2>
