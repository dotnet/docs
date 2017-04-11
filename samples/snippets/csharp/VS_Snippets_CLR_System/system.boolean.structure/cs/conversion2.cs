// <Snippet7>
using System;

public class Example
{
   public static void Main()
   {
      Double dbl = 1;
      int iterations = 0;
      for (int ctr = 1; ctr <= 5; ctr++) {
         dbl += .2;
         iterations++;
      }
      dbl -= 1 + iterations * .2;
      Console.WriteLine("{0} --> {1}", dbl, Convert.ToBoolean(dbl));
   }
}
// The example displays the following output:
//        -2.22044604925031E-16 --> True
// </Snippet7>
