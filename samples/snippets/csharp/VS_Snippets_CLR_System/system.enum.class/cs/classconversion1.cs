// <Snippet7>
using System;

public enum ArrivalStatus { Unknown=-3, Late=-1, OnTime=0, Early=1 };

public class Example
{
   public static void Main()
   {
      int[] values = { -3, -1, 0, 1, 5, Int32.MaxValue };
      foreach (var value in values)
      {
         ArrivalStatus status;
         if (Enum.IsDefined(typeof(ArrivalStatus), value))
            status = (ArrivalStatus) value;
         else
            status = ArrivalStatus.Unknown;
         Console.WriteLine("Converted {0:N0} to {1}", value, status);
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
