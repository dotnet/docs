
// <Snippet4>
using System;

public class Example
{
   public static void Main()
   {
      Single value = 123456789e4f;
      Single additional = Single.Epsilon * 1e12f;
      Console.WriteLine("{0} + {1} = {2}", value, additional, 
                                           value + additional);
   }
}
// The example displays the following output:
//    1.234568E+12 + 1.401298E-33 = 1.234568E+12
// </Snippet4>
