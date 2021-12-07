using System;

public class Example3
{
   public static void Main()
   {
      // <Snippet22>
      DateTime startDate = new DateTime(2015, 8, 28, 6, 0, 0);
      decimal[] temps = { 73.452m, 68.98m, 72.6m, 69.24563m,
                         74.1m, 72.156m, 72.228m };
      Console.WriteLine("{0,-20} {1,11}\n", "Date", "Temperature");
      for (int ctr = 0; ctr < temps.Length; ctr++)
         Console.WriteLine("{0,-20:g} {1,11:N1}", startDate.AddDays(ctr), temps[ctr]);

      // The example displays the following output:
      //       Date                 Temperature
      //
      //       8/28/2015 6:00 AM           73.5
      //       8/29/2015 6:00 AM           69.0
      //       8/30/2015 6:00 AM           72.6
      //       8/31/2015 6:00 AM           69.2
      //       9/1/2015 6:00 AM            74.1
      //       9/2/2015 6:00 AM            72.2
      //       9/3/2015 6:00 AM            72.2
      // </Snippet22>
   }
}
