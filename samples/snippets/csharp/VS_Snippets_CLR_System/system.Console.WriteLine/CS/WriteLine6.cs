// <Snippet6>
using System;

public class Example
{
   public static void Main()
   {
      Random rnd = new Random();
      // Generate five random Boolean values.
      for (int ctr = 1; ctr <= 5; ctr++) {
         Boolean bln = Convert.ToBoolean(rnd.Next(0, 2));
         Console.WriteLine("True or False: {0}", bln);
      }
   }
}
// The example displays the following output:
//       True or False: False
//       True or False: True
//       True or False: False
//       True or False: False
//       True or False: True
// </Snippet6>


