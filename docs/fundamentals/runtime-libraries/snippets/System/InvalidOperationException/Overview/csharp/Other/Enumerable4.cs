// <Snippet9>
using System;
using System.Linq;

public class EnumerableEx4
{
    public static void Main()
    {
        int[] dbQueryResults = { 1, 2, 3, 4 };

        var firstNum = dbQueryResults.FirstOrDefault(n => n > 4);

        if (firstNum == 0)
            Console.WriteLine("No value is greater than 4.");
        else
            Console.WriteLine($"The first value greater than 4 is {firstNum}");
    }
}
// The example displays the following output:
//       No value is greater than 4.
// </Snippet9>
