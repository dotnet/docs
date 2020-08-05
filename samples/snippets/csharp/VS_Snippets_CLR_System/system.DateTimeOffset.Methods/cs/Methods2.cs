// <Snippet7>
using System;

public class CompareTimes
{
   private enum TimeComparison
   {
      Earlier = -1,
      Same = 0,
      Later = 1
   };

   public static void Main()
   {
      DateTimeOffset firstTime = new DateTimeOffset(2007, 9, 1, 6, 45, 0,
                                 new TimeSpan(-7, 0, 0));

      DateTimeOffset secondTime = firstTime;
      Console.WriteLine("Comparing {0} and {1}: {2}",
                        firstTime, secondTime,
                        (TimeComparison) DateTimeOffset.Compare(firstTime, secondTime));

      secondTime = new DateTimeOffset(2007, 9, 1, 6, 45, 0,
                       new TimeSpan(-6, 0, 0));
      Console.WriteLine("Comparing {0} and {1}: {2}",
                       firstTime, secondTime,
                       (TimeComparison) DateTimeOffset.Compare(firstTime, secondTime));

      secondTime = new DateTimeOffset(2007, 9, 1, 8, 45, 0,
                       new TimeSpan(-5, 0, 0));
      Console.WriteLine("Comparing {0} and {1}: {2}",
                       firstTime, secondTime,
                       (TimeComparison) DateTimeOffset.Compare(firstTime, secondTime));
      // The example displays the following output to the console:
      //       Comparing 9/1/2007 6:45:00 AM -07:00 and 9/1/2007 6:45:00 AM -07:00: Same
      //       Comparing 9/1/2007 6:45:00 AM -07:00 and 9/1/2007 6:45:00 AM -06:00: Later
      //       Comparing 9/1/2007 6:45:00 AM -07:00 and 9/1/2007 8:45:00 AM -05:00: Same
   }
}
// </Snippet7>
