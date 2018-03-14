using System.Linq;
using System;
namespace Projection
{
    public class SelectManySample1
    {
        //This sample uses a compound from clause to make a query that returns all pairs of numbers from both arrays
        //such that the number from numbersA is less than the number from numbersB.
        //
        //Output:
        // Pairs where a<b:
        // 0 is less than 1
        // 0 is less than 3
        // 0 is less than 5
        // 0 is less than 7
        // 0 is less than 8
        // 2 is less than 3
        // 2 is less than 5
        // 2 is less than 7
        // 2 is less than 8
        // 4 is less than 5
        // 4 is less than 7
        // 4 is less than 8
        // 5 is less than 7
        // 5 is less than 8
        // 6 is less than 7
        // 6 is less than 8
        public static void QuerySyntaxExample()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs =
                from a in numbersA
                from b in numbersB
                where a < b
                select new { a, b };

            Console.WriteLine("Pairs where a < b:");
            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair.a} is less than {pair.b}");
            }
        }
    }
}