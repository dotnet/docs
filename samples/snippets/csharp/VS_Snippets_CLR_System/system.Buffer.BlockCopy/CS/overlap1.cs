using System;

public class Example
{
   public static void Main()
   {
      CopyUp();
      Console.WriteLine();
      CopyDown();
   }

   private static void CopyUp()
   {
      // <Snippet3>
      const int INT_SIZE = 4;
      int[] arr = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
      Buffer.BlockCopy(arr, 0 * INT_SIZE, arr, 3 * INT_SIZE, 4 * INT_SIZE);
      foreach (int value in arr)
         Console.Write("{0}  ", value);
      // The example displays the following output:
      //       2  4  6  2  4  6  8  16  18  20      
      // </Snippet3>
   }

   private static void CopyDown()
   {
      // <Snippet4>
      const int INT_SIZE = 4;
      int[] arr = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
      Buffer.BlockCopy(arr, 3 * INT_SIZE, arr, 0 * INT_SIZE, 4 * INT_SIZE);
      foreach (int value in arr)
         Console.Write("{0}  ", value);
      // The example displays the following output:
      //       8  10  12  14  10  12  14  16  18  20      
      // </Snippet4>
   }
}
