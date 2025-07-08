// <Snippet10>
using System;
using System.Linq;

public class EnumerableEx5
{
    public static void Main()
    {
        int[] dbQueryResults = { 1, 2, 3, 4 };

        var singleObject = dbQueryResults.Single(value => value > 4);

        // Display results.
        Console.WriteLine($"{singleObject} is the only value greater than 4");
    }
}
// The example displays the following output:
//    Unhandled Exception: System.InvalidOperationException:
//       Sequence contains no matching element
//       at System.Linq.Enumerable.Single[TSource](IEnumerable`1 source, Func`2 predicate)
//       at Example.Main()
// </Snippet10>
