// <Snippet1>
using System;

public class IsLeapYear
{
   public static void Main()
   {
      for (int year = 1994; year <= 2014; year++)
      {
         if (DateTime.IsLeapYear(year))
         {
            Console.WriteLine("{0} is a leap year.", year);
            DateTime leapDay = new DateTime(year, 2, 29);
            DateTime nextYear = leapDay.AddYears(1);
            Console.WriteLine("   One year from {0} is {1}.", 
                              leapDay.ToString("d"), 
                              nextYear.ToString("d"));
         }         
      }
   }
}
// The example produces the following output:
//       1996 is a leap year.
//          One year from 2/29/1996 is 2/28/1997.
//       2000 is a leap year.
//          One year from 2/29/2000 is 2/28/2001.
//       2004 is a leap year.
//          One year from 2/29/2004 is 2/28/2005.
//       2008 is a leap year.
//          One year from 2/29/2008 is 2/28/2009.
//       2012 is a leap year.
//          One year from 2/29/2012 is 2/28/2013.
// </Snippet1>
