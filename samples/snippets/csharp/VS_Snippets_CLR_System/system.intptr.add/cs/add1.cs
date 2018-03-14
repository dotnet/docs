// <Snippet1>
using System;
using System.Runtime.InteropServices;

public class Example
{
   public static void Main()
   {
      int[] arr = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
      unsafe {
         fixed(int* parr = arr) {
            IntPtr ptr = new IntPtr(parr);
            // Get the size of an array element.
            int size = sizeof(int);
            for (int ctr = 0; ctr < arr.Length; ctr++)
            {
               IntPtr newPtr = IntPtr.Add(ptr, ctr * size);
               Console.Write("{0}   ", Marshal.ReadInt32(newPtr));
            }
         }      
      }
   }
}
// The example displays the following output:
//       2   4   6   8   10   12   14   16   18   20
// </Snippet1>