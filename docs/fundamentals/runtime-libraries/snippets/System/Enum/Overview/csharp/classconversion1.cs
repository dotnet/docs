// <Snippet7>
using System;

public class Example3
{
    public static void Main()
    {
        int[] values = { -3, -1, 0, 1, 5, Int32.MaxValue };
        foreach (var value in values)
        {
            ArrivalStatus status;
            if (Enum.IsDefined(typeof(ArrivalStatus), value))
                status = (ArrivalStatus)value;
            else
                status = ArrivalStatus.Unknown;
            Console.WriteLine($"Converted {value:N0} to {status}");
        }
    }
}
// The example displays the following output:
//       Converted -3 to Unknown
//       Converted -1 to Late
//       Converted 0 to OnTime
//       Converted 1 to Early
//       Converted 5 to Unknown
//       Converted 2,147,483,647 to Unknown
// </Snippet7>
