// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      Array values = Array.CreateInstance(typeof(int), new int[] { 10 }, 
                                          new int[] { 1 });
      int value = 2;
      // Assign values.
      for (int ctr = values.GetLowerBound(0); ctr <= values.GetUpperBound(0); ctr++) {
         values.SetValue(value, ctr);
         value *= 2;
      }
      
      // Display values.
      for (int ctr = values.GetLowerBound(0); ctr <= values.GetUpperBound(0); ctr++)
         Console.Write("{0}    ", values.GetValue(ctr));
   }
}
// The example displays the following output:
//        2    4    8    16    32    64    128    256    512    1024
// </Snippet2>
