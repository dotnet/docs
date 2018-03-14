// <Snippet1>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      CultureInfo culture1 = CultureInfo.CurrentCulture;
      CultureInfo culture2 = Thread.CurrentThread.CurrentCulture;
      Console.WriteLine("The current culture is {0}", culture1.Name);
      Console.WriteLine("The two CultureInfo objects are equal: {0}",
                        culture1 == culture2);
   }
}
// The example displays output like the following:
//     The current culture is en-US
//     The two CultureInfo objects are equal: True
// </Snippet1>

