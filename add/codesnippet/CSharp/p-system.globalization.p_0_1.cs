using System;
using System.Globalization;
 
class Sample 
{
    public static void Main() 
    {
      PersianCalendar jc = new PersianCalendar();
      DateTime thisDate = DateTime.Now;
 
		//--------------------------------------------------------------------------------
		// Properties
		//--------------------------------------------------------------------------------
      Console.WriteLine("\n........... Selected Properties .....................\n");
      Console.Write("Eras:");
      foreach (int era in jc.Eras)
      {
         Console.WriteLine(" era = {0}", era);
      }
		//--------------------------------------------------------------------------------
      Console.WriteLine("\nTwoDigitYearMax = {0}", jc.TwoDigitYearMax);
		//--------------------------------------------------------------------------------
		// Methods
		//--------------------------------------------------------------------------------
      Console.WriteLine("\n............ Selected Methods .......................\n");
 
		//--------------------------------------------------------------------------------
      Console.WriteLine("GetDayOfYear: day = {0}", jc.GetDayOfYear(thisDate));
		//--------------------------------------------------------------------------------
      Console.WriteLine("GetDaysInMonth: days = {0}", 
                        jc.GetDaysInMonth( thisDate.Year, thisDate.Month, 
                        PersianCalendar.PersianEra));
		//--------------------------------------------------------------------------------
      Console.WriteLine("GetDaysInYear: days = {0}", 
                        jc.GetDaysInYear(thisDate.Year, PersianCalendar.PersianEra));
		//--------------------------------------------------------------------------------
      Console.WriteLine("GetLeapMonth: leap month (if any) = {0}", 
                        jc.GetLeapMonth(thisDate.Year, PersianCalendar.PersianEra));
		//-------------------------------------------------------------
      Console.WriteLine("GetMonthsInYear: months in a year = {0}", 
                        jc.GetMonthsInYear(thisDate.Year, PersianCalendar.PersianEra));
		//--------------------------------------------------------------------------------
      Console.WriteLine("IsLeapDay: This is a leap day = {0}", 
                        jc.IsLeapDay(thisDate.Year, thisDate.Month, thisDate.Day, 
                        PersianCalendar.PersianEra));
		//--------------------------------------------------------------------------------
      Console.WriteLine("IsLeapMonth: This is a leap month = {0}", 
                        jc.IsLeapMonth(thisDate.Year, thisDate.Month, 
                        PersianCalendar.PersianEra));
		//--------------------------------------------------------------------------------
      Console.WriteLine("IsLeapYear: 1370 is a leap year = {0}", 
                        jc.IsLeapYear(1370, PersianCalendar.PersianEra));
		//--------------------------------------------------------------------------------
 
		// Get the 4-digit year for a year whose last two digits are 99. The 4-digit year 
		// depends on the current value of the TwoDigitYearMax property.
 
      Console.WriteLine("ToFourDigitYear:");
      Console.WriteLine("  If TwoDigitYearMax = {0}, ToFourDigitYear(99) = {1}", 
                         jc.TwoDigitYearMax, jc.ToFourDigitYear(99));
      jc.TwoDigitYearMax = thisDate.Year;
      Console.WriteLine("  If TwoDigitYearMax = {0}, ToFourDigitYear(99) = {1}", 
                        jc.TwoDigitYearMax, jc.ToFourDigitYear(99));
    }
}
// The example displays the following output:
//       ........... Selected Properties .....................
//       
//       Eras: era = 1
//       
//       TwoDigitYearMax = 99
//       
//       ............ Selected Methods .......................
//       
//       GetDayOfYear: day = 1
//       GetDaysInMonth: days = 31
//       GetDaysInYear: days = 365
//       GetLeapMonth: leap month (if any) = 0
//       GetMonthsInYear: months in a year = 12
//       IsLeapDay: This is a leap day = False
//       IsLeapMonth: This is a leap month = False
//       IsLeapYear: 1370 is a leap year = True
//       ToFourDigitYear:
//         If TwoDigitYearMax = 99, ToFourDigitYear(99) = 99
//         If TwoDigitYearMax = 2012, ToFourDigitYear(99) = 1999