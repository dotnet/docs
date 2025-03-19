// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      TimeSpan interval1, interval2;
      interval1 = new TimeSpan(7, 45, 16);
      interval2 = new TimeSpan(18, 12, 38);

      Console.WriteLine($"{interval1:c} - {interval2:c} = {interval1 - interval2:c}");
      Console.WriteLine($"{interval1:c} + {interval2:c} = {interval1 + interval2:c}");

      interval1 = new TimeSpan(0, 0, 1, 14, 365);
      interval2 = TimeSpan.FromTicks(2143756);
      Console.WriteLine($"{interval1:c} + {interval2:c} = {interval1 + interval2:c}");
   }
}
// The example displays the following output:
//       07:45:16 - 18:12:38 = -10:27:22
//       07:45:16 + 18:12:38 = 1.01:57:54
//       00:01:14.3650000 + 00:00:00.2143756 = 00:01:14.5793756
// </Snippet1>