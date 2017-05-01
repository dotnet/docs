// <Snippet11>
using System;

public class Example
{
   public static void Main()
   {
       int[] values = new int[10];
       for (int ctr = 0; ctr <= 9; ctr++)
          values[ctr] = ctr * 2;
          
       foreach (var value in values)
          Console.WriteLine(value);   
   }
}
// The example displays the following output:
//    0
//    2
//    4
//    6
//    8
//    10
//    12
//    14
//    16
//    18
// </Snippet11>

