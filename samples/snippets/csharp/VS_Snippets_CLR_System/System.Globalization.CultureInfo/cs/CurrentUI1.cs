// <Snippet2>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      CultureInfo uiCulture1 = CultureInfo.CurrentUICulture;
      CultureInfo uiCulture2 = Thread.CurrentThread.CurrentUICulture;
      Console.WriteLine("The current UI culture is {0}", uiCulture1.Name);
      Console.WriteLine("The two CultureInfo objects are equal: {0}",
                        uiCulture1 == uiCulture2);
   }
}
// The example displays output like the following:
//     The current UI culture is en-US
//     The two CultureInfo objects are equal: True
// </Snippet2>

