using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      UIntPtr ptr = (UIntPtr) arr[0];
      for (int ctr = 0; ctr < arr.Length; ctr++)
      {
         UIntPtr newPtr = ptr + ctr;
         Console.WriteLine(newPtr);
      } 
      // </Snippet1>  
   }
}
