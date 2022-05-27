// <Snippet18>
using System;
using System.Globalization;
using System.Threading;

public class Example17
{
   public static void Main17()
   {
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("pl-PL");
      string composite = "\u0041\u0300";
      Console.WriteLine("Comparing using Char:   {0}", composite.IndexOf('\u00C0'));
      Console.WriteLine("Comparing using String: {0}", composite.IndexOf("\u00C0"));
   }
}
// The example displays the following output:
//       Comparing using Char:   -1
//       Comparing using String: 0
// </Snippet18>
