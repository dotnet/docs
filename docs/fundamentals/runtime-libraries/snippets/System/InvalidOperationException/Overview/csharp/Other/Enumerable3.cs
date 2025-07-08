// <Snippet8>
using System;
using System.Linq;

public class EnumerableEx3
{
    public static void Main()
    {
        int[] dbQueryResults = { 1, 2, 3, 4 };

        var firstNum = dbQueryResults.First(n => n > 4);

        Console.WriteLine($"The first value greater than 4 is {firstNum}");
    }
}
// The example displays the following output:
//    Unhandled Exception: System.InvalidOperationException:
//       Sequence contains no matching element
//       at System.Linq.Enumerable.First[TSource](IEnumerable`1 source, Func`2 predicate)
//       at Example.Main()
// </Snippet8>
