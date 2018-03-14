// <Snippet2>
using System;
using System.Globalization;
using System.Text;

public class Example
{
   public static void Main()
   {
      StringBuilder sb = new StringBuilder();
      Decimal value = 16.95m;
      CultureInfo enGB = CultureInfo.CreateSpecificCulture("en-GB");
      DateTime dateToday = DateTime.Now;
      sb.AppendFormat(enGB, "Final Price: {0:C2}", value);
      sb.AppendLine();
      sb.AppendFormat(enGB, "Date and Time: {0:d} at {0:t}", dateToday);
      Console.WriteLine(sb.ToString());
   }
}
// The example displays the following output:
//       Final Price: £16.95
//       Date and Time: 01/10/2014 at 10:22
// </Snippet2>
