// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      DateTime dec31 = new DateTime(2010, 12, 31);
      for (int ctr = 0; ctr <= 10; ctr++) {
         DateTime dateToDisplay = dec31.AddYears(ctr);
         Console.WriteLine("{0:d}: day {1} of {2} {3}", dateToDisplay, 
                           dateToDisplay.DayOfYear,
                           dateToDisplay.Year,   
                           DateTime.IsLeapYear(dateToDisplay.Year) ? 
                                               "(Leap Year)" : ""); 
      }  

   }
}
// The example displays the following output:
//       12/31/2010: day 365 of 2010
//       12/31/2011: day 365 of 2011
//       12/31/2012: day 366 of 2012 (Leap Year)
//       12/31/2013: day 365 of 2013
//       12/31/2014: day 365 of 2014
//       12/31/2015: day 365 of 2015
//       12/31/2016: day 366 of 2016 (Leap Year)
//       12/31/2017: day 365 of 2017
//       12/31/2018: day 365 of 2018
//       12/31/2019: day 365 of 2019
//       12/31/2020: day 366 of 2020 (Leap Year)
// </Snippet1>
