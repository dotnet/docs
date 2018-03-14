// <Snippet1>
using System;
using System.Runtime.InteropServices;

public class Example
{
   public static void Main()
   {
      int[] arr = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20};
      // Get the size of a single array element.
      int size = sizeof(int);
      unsafe {
         fixed(int* pend = &arr[arr.GetUpperBound(0)]) {
            IntPtr ptr = new IntPtr(pend);
            for (int ctr = 0; ctr < arr.Length; ctr++)
            {
               IntPtr newPtr = IntPtr.Subtract(ptr, ctr * size);
               Console.Write("{0}   ", Marshal.ReadInt32(newPtr));
            }
         }
      }
   }
}
// The example displays the following output:
//       20   18   16   14   12   10   8   6   4   2
// </Snippet1>