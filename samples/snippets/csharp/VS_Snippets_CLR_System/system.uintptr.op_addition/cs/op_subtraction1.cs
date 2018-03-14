using System;

public class Example
{
   public static void Main()
   {
      // <Snippet2>
      int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
      UIntPtr ptr = (UIntPtr) arr[arr.GetUpperBound(0)];
      for (int ctr = 0; ctr <= arr.GetUpperBound(0); ctr++)
      {
         UIntPtr newPtr = ptr - ctr;
         Console.Write("{0}   ", newPtr);
      }
      // </Snippet2>
   }
}
