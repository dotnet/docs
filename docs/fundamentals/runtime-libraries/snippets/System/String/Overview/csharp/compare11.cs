// <Snippet10>
using System;
using System.Globalization;
using System.Threading;

public class Example2
{
   public static void Main()
   {
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
      Console.WriteLine(String.Compare("A", "a", StringComparison.CurrentCulture));
      Console.WriteLine(String.Compare("A", "a", StringComparison.Ordinal));
   }
}
// The example displays the following output:
//       1
//       -32
// </Snippet10>
