// <Snippet3>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      DateTimeOffset date1 = new DateTimeOffset(new DateTime(1550, 7, 21),
                                                TimeSpan.Zero);
      CultureInfo dft;
      CultureInfo heIL = new CultureInfo("he-IL");
      heIL.DateTimeFormat.Calendar = new HebrewCalendar();
      
      // Change current culture to he-IL.
      dft = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = heIL;
      
      // Display the date using the current culture's calendar.            
      try {
         Console.WriteLine(date1.ToString("G"));
      }   
      catch (ArgumentOutOfRangeException) {
         Console.WriteLine("{0} is earlier than {1} or later than {2}", 
                           date1.ToString("d", CultureInfo.InvariantCulture), 
                           heIL.DateTimeFormat.Calendar.MinSupportedDateTime.ToString("d", CultureInfo.InvariantCulture),  
                           heIL.DateTimeFormat.Calendar.MaxSupportedDateTime.ToString("d", CultureInfo.InvariantCulture)); 
      }
      
      // Restore the default culture.
      Thread.CurrentThread.CurrentCulture = dft;
   }
}
// The example displays the following output:
//    07/21/1550 is earlier than 01/01/1583 or later than 09/29/2239
// </Snippet3>
