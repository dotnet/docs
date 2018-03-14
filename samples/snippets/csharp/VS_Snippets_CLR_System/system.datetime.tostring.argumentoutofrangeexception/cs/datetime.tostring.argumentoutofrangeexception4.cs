// <Snippet4>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo arSA = new CultureInfo("ar-SA");
      arSA.DateTimeFormat.Calendar = new UmAlQuraCalendar(); 
      DateTime date1 = new DateTime(1890, 9, 10);

      try {
         Console.WriteLine(date1.ToString("d", arSA));
      }   
      catch (ArgumentOutOfRangeException) {
         Console.WriteLine("{0:d} is earlier than {1:d} or later than {2:d}", 
                           date1, 
                           arSA.DateTimeFormat.Calendar.MinSupportedDateTime,  
                           arSA.DateTimeFormat.Calendar.MaxSupportedDateTime); 
      }
   }
}
// The example displays the following output:
//    9/10/1890 is earlier than 4/30/1900 or later than 5/13/2029
// </Snippet4>
