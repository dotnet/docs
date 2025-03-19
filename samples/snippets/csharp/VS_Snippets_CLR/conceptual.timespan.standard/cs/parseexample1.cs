// <Snippet3>
using System;

public class Example
{
   public static void Main()
   {
      string value = "1.03:14:56.1667";
      TimeSpan interval;
      try {
         interval = TimeSpan.ParseExact(value, "c", null);
         Console.WriteLine($"Converted '{value}' to {interval}");
      }
      catch (FormatException) {
         Console.WriteLine($"{value}: Bad Format");
      }
      catch (OverflowException) {
         Console.WriteLine($"{value}: Out of Range");
      }

      if (TimeSpan.TryParseExact(value, "c", null, out interval))
         Console.WriteLine($"Converted '{value}' to {interval}");
      else
         Console.WriteLine($"Unable to convert {value} to a time interval.");
   }
}
// The example displays the following output:
//       Converted '1.03:14:56.1667' to 1.03:14:56.1667000
//       Converted '1.03:14:56.1667' to 1.03:14:56.1667000
// </Snippet3>