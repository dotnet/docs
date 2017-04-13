// <Snippet2>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      DateTimeOffset date1 = new DateTimeOffset(new DateTime(550, 1, 1),
                                                TimeSpan.Zero);
      CultureInfo dft;
      CultureInfo arSY = new CultureInfo("ar-SY");
      arSY.DateTimeFormat.Calendar = new HijriCalendar();
      
      // Change current culture to ar-SY.
      dft = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = arSY;
      
      // Display the date using the current culture's calendar.            
      try {
         Console.WriteLine(date1.ToString());
      }
      catch (ArgumentOutOfRangeException) {
         Console.WriteLine("{0} is earlier than {1} or later than {2}", 
                           date1.ToString("d", CultureInfo.InvariantCulture), 
                           arSY.DateTimeFormat.Calendar.MinSupportedDateTime.ToString("d", CultureInfo.InvariantCulture),  
                           arSY.DateTimeFormat.Calendar.MaxSupportedDateTime.ToString("d", CultureInfo.InvariantCulture)); 
      }
      
      // Restore the default culture.
      Thread.CurrentThread.CurrentCulture = dft;
   }
}
// The example displays the following output:
//    01/01/0550 is earlier than 07/18/0622 or later than 12/31/9999
// </Snippet2>
