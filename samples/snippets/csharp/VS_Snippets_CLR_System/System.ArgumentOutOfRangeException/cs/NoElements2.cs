// <Snippet13>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      var numbers = new List<int>();
      numbers.AddRange( new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 20 } );
      
      var squares = new List<int>();
      for (int ctr = 0; ctr < numbers.Count; ctr++)
         squares[ctr] = (int) Math.Pow(numbers[ctr], 2); 
   }
}
// The example displays the following output:
//    Unhandled Exception: System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection.
//    Parameter name: index
//       at System.ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
//       at Example.Main()
// </Snippet13>

class Correction
{
   public void Test()
   {
      var numbers = new List<int>();
      numbers.AddRange( new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 20 } );
      
      
      // <Snippet14>
      var squares = new List<int>();
      for (int ctr = 0; ctr < numbers.Count; ctr++)
         squares.Add((int) Math.Pow(numbers[ctr], 2)); 
      // </Snippet14>
   }
}
