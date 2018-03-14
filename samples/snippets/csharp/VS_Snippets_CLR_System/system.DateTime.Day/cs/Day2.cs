using System;
using System.Globalization;
using System.Threading;

public class Class1
{
   public static void Main()
   {
      // <Snippet2>
      CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

      // Change current culture to ar-SA.
      CultureInfo ci = new CultureInfo("ar-SA");
      Thread.CurrentThread.CurrentCulture = ci;
      
      DateTime hijriDate = new DateTime(1430, 1, 17, 
                               Thread.CurrentThread.CurrentCulture.Calendar);
      // Display date (uses calendar of current culture by default).
      Console.WriteLine(hijriDate.ToString("dd-MM-yyyy"));
      // Displays 17-01-1430.

      // Display day of 17th of Muharram
      Console.WriteLine(hijriDate.Day);
      // Displays 13 (corresponding day of January in Gregorian calendar).
      
      // Display day of 17th of Muharram in Hijri calendar.
      Console.WriteLine(Thread.CurrentThread.CurrentCulture.Calendar.GetDayOfMonth(hijriDate));
      // Displays 17.
      
      Thread.CurrentThread.CurrentCulture = originalCulture;  
      // </Snippet2>
   }
}
