// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      var dat = new DateTime(2015, 12, 31);
      for (int ctr = 0; ctr <= 15; ctr++)
         Console.WriteLine(dat.AddMonths(ctr).ToString("d"));

   }
}
// The example displays the following output:
//       12/31/2015
//       1/31/2016
//       2/29/2016
//       3/31/2016
//       4/30/2016
//       5/31/2016
//       6/30/2016
//       7/31/2016
//       8/31/2016
//       9/30/2016
//       10/31/2016
//       11/30/2016
//       12/31/2016
//       1/31/2017
//       2/28/2017
//       3/31/2017
// </Snippet1>
