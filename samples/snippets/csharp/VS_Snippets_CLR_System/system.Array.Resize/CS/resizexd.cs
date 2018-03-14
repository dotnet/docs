// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      int[,] arr = new int[10,2];
      for (int n1 = 0; n1 <= arr.GetUpperBound(0); n1++) {
         arr[n1, 0] = n1;
         arr[n1, 1] = n1 * 2;
      } 

      // Make a 2-D array larger in the first dimension.
      arr = (int[,]) ResizeArray(arr, new int[] { 12, 2} );
      for (int ctr = 0; ctr <= arr.GetUpperBound(0); ctr++) 
         Console.WriteLine("{0}: {1}, {2}", ctr, arr[ctr, 0], arr[ctr, 1]);
      Console.WriteLine();


      // Make a 2-D array smaller in the first dimension.
      arr = (int[,]) ResizeArray(arr, new int[] { 2, 2} );
      for (int ctr = 0; ctr <= arr.GetUpperBound(0); ctr++) 
         Console.WriteLine("{0}: {1}, {2}", ctr, arr[ctr, 0], arr[ctr, 1]);
   }

   private static Array ResizeArray(Array arr, int[] newSizes)
   {
      if (newSizes.Length != arr.Rank)
         throw new ArgumentException("arr must have the same number of dimensions " +
                                     "as there are elements in newSizes", "newSizes"); 

      var temp = Array.CreateInstance(arr.GetType().GetElementType(), newSizes);
      int length = arr.Length <= temp.Length ? arr.Length : temp.Length;
      Array.ConstrainedCopy(arr, 0, temp, 0, length);
      return temp;
   }   
}
// The example displays the following output:
//       0: 0, 0
//       1: 1, 2
//       2: 2, 4
//       3: 3, 6
//       4: 4, 8
//       5: 5, 10
//       6: 6, 12
//       7: 7, 14
//       8: 8, 16
//       9: 9, 18
//       10: 0, 0
//       11: 0, 0
//       
//       0: 0, 0
//       1: 1, 2
// </Snippet2>
