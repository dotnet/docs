// <Snippet1>
using System;
using System.Collections.Generic;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      UmAlQuraCalendar cal = new UmAlQuraCalendar();
      List<string> months = new List<string>();
      string output = String.Empty;
      
      // Get the current year in the UmAlQura calendar.
      int startYear = cal.GetYear(DateTime.Now);
      // Display the number of days in each month for the next five years.
      Console.WriteLine("          Days in Each Month, {0} to {1}\n",
                        startYear, startYear + 4);

      Console.WriteLine("Month     {0}     {1}     {2}     {3}     {4}",
                        startYear, startYear + 1, startYear + 2, startYear + 3, 
                        startYear + 4);
      for (int year = startYear; year <= startYear + 4; year++) {
         int days;
         for (int month = 1; month <= cal.GetMonthsInYear(year, UmAlQuraCalendar.UmAlQuraEra);
                             month++)
         {
            days = cal.GetDaysInMonth(year, month, 
                                      UmAlQuraCalendar.UmAlQuraEra);
            output = String.Format("{0}     ", days);
            if (months.Count < month)
               months.Add(String.Format("{0,4}        {1}", 
                                        month, output));
            else
               months[month - 1] += "  " + output;

         }         
      }                  
      
      foreach (var item in months)
         Console.WriteLine(item);
   }
}
// The example displays the following output:
//                 Days in Each Month, 1431 to 1435
//       
//       Month     1431     1432     1433     1434     1435
//          1        29       29       30       29       30
//          2        30       30       29       30       29
//          3        30       30       30       29       30
//          4        29       30       30       30       29
//          5        30       29       29       29       30
//          6        29       30       30       30       29
//          7        30       29       30       30       30
//          8        29       30       29       29       29
//          9        30       29       30       30       30
//         10        29       30       29       30       30
//         11        29       29       30       29       29
//         12        30       29       29       29       30
// </Snippet1>