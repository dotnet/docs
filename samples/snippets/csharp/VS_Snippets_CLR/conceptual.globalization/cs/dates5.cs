// <Snippet8>
using System;

public class Example7
{
   public static void Main7()
   {
      DateTime date1 = DateTime.SpecifyKind(new DateTime(2013, 3, 9, 10, 30, 0),
                                            DateTimeKind.Local);
      TimeSpan interval = new TimeSpan(48, 0, 0);
      DateTime date2 = date1 + interval;
      Console.WriteLine("{0:g} + {1:N1} hours = {2:g}",
                        date1, interval.TotalHours, date2);
   }
}
// The example displays the following output:
//        3/9/2013 10:30 AM + 48.0 hours = 3/11/2013 10:30 AM
// </Snippet8>
