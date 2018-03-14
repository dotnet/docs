// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      UIntPtr ptr = (UIntPtr) arr[0];
      for (int ctr = 0; ctr < arr.Length; ctr++)
      {
         UIntPtr newPtr = UIntPtr.Add(ptr, ctr);
         Console.Write("{0}   ", newPtr);
      }      
   }
}
// The example displays the following output:
//       1   2   3   4   5   6   7   8   9   10
// </Snippet1>