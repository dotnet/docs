// <Snippet2>
using System;

delegate int del(int i);  

public class Example
{
   static void Main()  
   {  
      ShowValue(x => x * x);  
   }  

   private static void ShowValue(Func<int,int> op)
   {
      for (int ctr = 1; ctr <= 5; ctr++)
         Console.WriteLine("{0} x {0} = {1}",
                           ctr,  op(ctr));
   }
}
// The example displays the following output:
//   1, 1 x 1 = 1
//   2, 2 x 2 = 4
//   3, 3 x 3 = 9
//   4, 4 x 4 = 16
//   5, 5 x 5 = 25
// </Snippet2>
