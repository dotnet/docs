// <Snippet2>
using System;

public class Example3
{
   public static void Main()
   {
      TimeSpan interval = DateTime.Now - DateTime.Now.Date;
      string msg = String.Format("Elapsed Time Today: {0:d} hours.",
                                 interval);
      Console.WriteLine(msg);
   }
}
// The example displays the following output:
//       Elapsed Time Today: 01:40:52.2524662 hours.
// </Snippet2>
