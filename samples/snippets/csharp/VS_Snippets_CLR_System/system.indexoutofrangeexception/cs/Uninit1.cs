
// <Snippet10>
public class Example
{
   public static void Main()
   {
      int[] values1 = { 3, 6, 9, 12, 15, 18, 21 };
      int[] values2 = new int[6];
      
      // Assign last element of the array to the new array.
      values2[values1.Length - 1] = values1[values1.Length - 1];
   }
}
// The example displays the following output:
//       Unhandled Exception: 
//       System.IndexOutOfRangeException: 
//       Index was outside the bounds of the array.
//       at Example.Main()
// </Snippet10>
