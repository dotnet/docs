// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
      UIntPtr ptr = (UIntPtr) arr[arr.GetUpperBound(0)];
      for (int ctr = 0; ctr <= arr.GetUpperBound(0); ctr++)
      {
         UIntPtr newPtr = UIntPtr.Subtract(ptr, ctr);
         Console.Write("{0}   ", newPtr);
      }
   }
}
// The example displays the following output:
//       10   9   8   7   6   5   4   3   2   1
// </Snippet1>