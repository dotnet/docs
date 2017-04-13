using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      // <Snippet1>
      // Return day of 1/13/2009.
      DateTime dateGregorian = new DateTime(2009, 1, 13);
      Console.WriteLine(dateGregorian.Day);              
      // Displays 13 (Gregorian day).
      
      // Create date of 1/13/2009 using Hijri calendar.
      HijriCalendar hijri = new HijriCalendar();
      DateTime dateHijri = new DateTime(1430, 1, 17, hijri);
      // Return day of date created using Hijri calendar.
      Console.WriteLine(dateHijri.Day);                    
      // Displays 13 (Gregorian day).
      
      // Display day of date in Hijri calendar.
      Console.WriteLine(hijri.GetDayOfMonth(dateHijri));   
      // Displays 17 (Hijri day).
      // </Snippet1>
   }
}
