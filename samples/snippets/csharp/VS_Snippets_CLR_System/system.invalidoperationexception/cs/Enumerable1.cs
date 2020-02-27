// <Snippet6>
using System;
using System.Linq;

public class Example
{
   public static void Main()
   {
      int[] data = { 1, 2, 3, 4 };
      var average = data.Where(num => num > 4).Average();
      Console.Write("The average of numbers greater than 4 is {0}",
                    average);
   }
}
// The example displays the following output:
//    Unhandled Exception: System.InvalidOperationException: Sequence contains no elements
//       at System.Linq.Enumerable.Average(IEnumerable`1 source)
//       at Example.Main()
// </Snippet6>
