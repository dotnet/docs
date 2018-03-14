// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      var startWork = new TimeSpan(08,00,00);
      var endWork = new TimeSpan(18,30,00);
      var lunchBreak = new TimeSpan(1, 0, 0);
      var breaks = new TimeSpan(0, 30, 0);
      
      Console.WriteLine("Length of work day: {0}", 
                        endWork - startWork);
      Console.WriteLine("Actual time worked: {0}",
                        endWork - startWork - (lunchBreak + breaks));                  
   }
}
// The example displays the following output:
//     Length of work day: 10:30:00
//     Actual time worked: 09:00:00
// </Snippet2>

