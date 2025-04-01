// <Snippet7>
using System;
using System.Linq;

public class EnumerableEx2
{
    public static void Main()
    {
        int[] dbQueryResults = { 1, 2, 3, 4 };
        var moreThan4 = dbQueryResults.Where(num => num > 4);

        if (moreThan4.Any())
            Console.WriteLine($"Average value of numbers greater than 4: {moreThan4.Average()}:");
        else
            // handle empty collection
            Console.WriteLine("The dataset has no values greater than 4.");
    }
}
// The example displays the following output:
//       The dataset has no values greater than 4.
// </Snippet7>
