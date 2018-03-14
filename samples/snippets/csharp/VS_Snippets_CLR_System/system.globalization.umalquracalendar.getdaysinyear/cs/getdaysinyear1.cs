// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      Calendar cal = new UmAlQuraCalendar();
      int currentYear = cal.GetYear(DateTime.Now);
      
      Console.WriteLine("Era     Year     Days\n");
      foreach (int era in cal.Eras) {
         for (int year = currentYear; year <= currentYear + 9; year++) {
            Console.WriteLine("{0}{1}      {2}      {3}", 
                              ShowCurrentEra(cal, era), era, year, 
                              cal.GetDaysInYear(year, era));   
         }     
      }   
      Console.WriteLine("\n   * Indicates the current era.");
   }

   private static string ShowCurrentEra(Calendar cal, int era)
   {
      if (era == cal.Eras[Calendar.CurrentEra])
         return "*";
      else
         return " ";
   }
}
// The example displays the following output:
//       Era     Year     Days
//       
//       *1      1431      354
//       *1      1432      354
//       *1      1433      355
//       *1      1434      354
//       *1      1435      355
//       *1      1436      354
//       *1      1437      354
//       *1      1438      354
//       *1      1439      355
//       *1      1440      354
//       
//          * Indicates the current era.
// </Snippet1>