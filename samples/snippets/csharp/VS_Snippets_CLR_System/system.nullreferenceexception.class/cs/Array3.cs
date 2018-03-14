// <Snippet10>
using System;

public class Example
{
   public static void Main()
   {
       int[] values = null;
       for (int ctr = 0; ctr <= 9; ctr++)
          values[ctr] = ctr * 2;
          
       foreach (var value in values)
          Console.WriteLine(value);   
   }
}
// The example displays the following output:
//    Unhandled Exception: 
//       System.NullReferenceException: Object reference not set to an instance of an object.
//       at Example.Main()
// </Snippet10>

