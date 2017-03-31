// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      var faIR = new CultureInfo("fa-IR");
      var value = DateTime.Parse("08/03/1395", faIR);
      Console.WriteLine(value.ToString(faIR));
      
      faIR.DateTimeFormat.Calendar = new GregorianCalendar();
      Console.WriteLine(value.ToString(faIR));
   }
}
// The example displays the following output:
//       08/03/1395 12:00:00 ?.?
//       28/05/2016 12:00:00 ?.?
// </Snippet2>

