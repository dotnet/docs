// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      DateTime[] dates = { DateTime.Now, 
                           new DateTime(2013, 9, 14, 9, 28, 0),
                           new DateTime(2011, 5, 28, 10, 35, 0),
                           new DateTime(1979, 12, 25, 14, 30, 0) };
      foreach (var date in dates) {
         Console.WriteLine("Day: {0:d} Time: {1:g}", date.Date, date.TimeOfDay);
         Console.WriteLine("Day: {0:d} Time: {0:t}\n", date);
      }                              
   }
}
// The example displays output like the following:
//    Day: 7/25/2012 Time: 10:08:12.9713744
//    Day: 7/25/2012 Time: 10:08 AM
//    
//    Day: 9/14/2013 Time: 9:28:00
//    Day: 9/14/2013 Time: 9:28 AM
//    
//    Day: 5/28/2011 Time: 10:35:00
//    Day: 5/28/2011 Time: 10:35 AM
//    
//    Day: 12/25/1979 Time: 14:30:00
//    Day: 12/25/1979 Time: 2:30 PM
// </Snippet1>
