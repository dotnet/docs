// <Snippet29>
using System;

public class Example
{
   public static void Main()
   {
      TimeSpan result = new DateTime(2010, 01, 01) - DateTime.Now;
      String fmt = (result < TimeSpan.Zero ?  "\\-" : "") + "dd\\.hh\\:mm";

      Console.WriteLine(result.ToString(fmt));
      Console.WriteLine($"Interval: {result:" + fmt + "}");
   }
}
// The example displays output like the following:
//       -1291.10:54
//       Interval: -1291.10:54
// </Snippet29>
