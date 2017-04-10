// <Snippet3>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      var faIR = new CultureInfo("fa-IR");
      var dat = new DateTime(1395, 8, 18, faIR.DateTimeFormat.Calendar);
      Console.WriteLine("Umm-al-Qura date: {0}", dat.ToString("d", faIR));
      Console.WriteLine("Gregorian date:   {0:d}", dat);
   }
}
// The example displays the following output:
//       Umm-al-Qura date: 18/08/1395
//       Gregorian date:   11/8/2016
// </Snippet3>

