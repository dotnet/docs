// <Snippet5>
using System;
using System.Linq;

public class NullableEx2
{
   public static void Main()
   {
      var queryResult = new int?[] { 1, 2, null, 4 };
      var numbers = queryResult.Select(nullableInt => (int)nullableInt.GetValueOrDefault());

      // Display list using Nullable<int>.HasValue.
      foreach (var number in numbers)
         Console.Write("{0} ", number);
      Console.WriteLine();

      numbers = queryResult.Select(nullableInt => (int) (nullableInt.HasValue ? nullableInt : -1));
      // Display list using Nullable<int>.GetValueOrDefault.
      foreach (var number in numbers)
         Console.Write("{0} ", number);
      Console.WriteLine();
   }
}
// The example displays the following output:
//       1 2 0 4
//       1 2 -1 4
// </Snippet5>
