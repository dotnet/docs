// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      string dateFormat = "MM/dd/yyyy hh:mm:ss";
      DateTime date1 = new DateTime(2014, 9, 8, 16, 0, 0);
      Console.WriteLine("Original date: {0} ({1:N0} ticks)\n",
                        date1.ToString(dateFormat), date1.Ticks);
      
      DateTime date2 = date1.AddSeconds(30);
      Console.WriteLine("Second date:   {0} ({1:N0} ticks)",
                        date2.ToString(dateFormat), date2.Ticks);
      Console.WriteLine("Difference between dates: {0} ({1:N0} ticks)\n",
                        date2 - date1, date2.Ticks - date1.Ticks);                        
      
      // Add 1 day's worth of seconds (60 secs. * 60 mins * 24 hrs.
      DateTime date3 = date1.AddSeconds(60 * 60 * 24);
      Console.WriteLine("Third date:    {0} ({1:N0} ticks)",
                        date3.ToString(dateFormat), date3.Ticks);
      Console.WriteLine("Difference between dates: {0} ({1:N0} ticks)",
                        date3 - date1, date3.Ticks - date1.Ticks);                        
   }
}
// The example displays the following output:
//    Original date: 09/08/2014 04:00:00 (635,457,888,000,000,000 ticks)
//
//    Second date:   09/08/2014 04:00:30 (635,457,888,300,000,000 ticks)
//    Difference between dates: 00:00:30 (300,000,000 ticks)
//
//    Third date:    09/09/2014 04:00:00 (635,458,752,000,000,000 ticks)
//    Difference between dates: 1.00:00:00 (864,000,000,000 ticks)
// </Snippet1>
