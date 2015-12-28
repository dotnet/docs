using System;
using System.Linq;

namespace Conversion
{
    public static class ToArraySample1
    {
        //This sample uses ToArray and query syntax to immediately evaluate a sequence into an array.
        //
        //Output:
        // Every other double from highest to lowest:
        // 4.1
        // 2.3
        // 1.7
        public static void QuerySyntaxExample()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            var sortedDoubles =
                from d in doubles
                orderby d descending
                select d;
            var doublesArray = sortedDoubles.ToArray();

            Console.WriteLine("Every other double from highest to lowest:");
            for (int d = 0; d < doublesArray.Length; d += 2)
            {
                Console.WriteLine(doublesArray[d]);
            }
        }

        //This sample uses ToArray and method syntax to immediately evaluate a sequence into an array.
        //
        //Output:
        // Every other double from highest to lowest:
        // 4.1
        // 2.3
        // 1.7
        public static void MethodSyntaxExample()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            var sortedDoubles =
                doubles.OrderByDescending(d => d);
            var doublesArray = sortedDoubles.ToArray();

            Console.WriteLine("Every other double from highest to lowest:");
            for (int d = 0; d < doublesArray.Length; d += 2)
            {
                Console.WriteLine(doublesArray[d]);
            }
        }
    }
}
