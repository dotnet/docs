// <Snippet4>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      TimeSpan interval1, interval2;
      interval1 = new TimeSpan(7, 45, 16);
      interval2 = new TimeSpan(18, 12, 38);

      Console.WriteLine($"{interval1:g} - {interval2:g} = {interval1 - interval2:g}");
      Console.WriteLine(String.Format(new CultureInfo("fr-FR"),
                        "{0:g} + {1:g} = {2:g}", interval1,
                        interval2, interval1 + interval2));

      interval1 = new TimeSpan(0, 0, 1, 14, 36);
      interval2 = TimeSpan.FromTicks(2143756);
      Console.WriteLine($"{interval1:g} + {interval2:g} = {interval1 + interval2:g}");
   }
}
// The example displays the following output:
//       7:45:16 - 18:12:38 = -10:27:22
//       7:45:16 + 18:12:38 = 1:1:57:54
//       0:01:14.036 + 0:00:00.2143756 = 0:01:14.2503756
// </Snippet4>