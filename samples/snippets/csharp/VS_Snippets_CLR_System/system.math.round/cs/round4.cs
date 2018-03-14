// <Snippet3>
using System;

public class Example
{
   public static void Main()
   {
      double[] values = { 2.125, 2.135, 2.145, 3.125, 3.135, 3.145 };
      foreach (double value in values)
         Console.WriteLine("{0} --> {1}", value, 
                           Math.Round(value, 2, MidpointRounding.AwayFromZero));

   }
}
// The example displays the following output:
//       2.125 --> 2.13
//       2.135 --> 2.13
//       2.145 --> 2.15
//       3.125 --> 3.13
//       3.135 --> 3.14
//       3.145 --> 3.15
// </Snippet3>
