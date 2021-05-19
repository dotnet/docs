using System;

namespace IterationStatements
{
    public static class ForStatement
    {
        public static void Examples()
        {
            Typical();
            MultipleExpressions();
        }

        private static void Typical()
        {
            // <TypicalExample>
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(i);
            }
            // Output:
            // 0
            // 1
            // 2
            // </TypicalExample>
        }

        private static void MultipleExpressions()
        {
            // <MultipleExpressions>
            int i;
            int j = 3;
            for (i = 0, Console.WriteLine($"Start: i={i}, j={j}"); i < j; i++, j--, Console.WriteLine($"Step: i={i}, j={j}"))
            {
                // Body of the loop.
            }
            // Output:
            // Start: i=0, j=3
            // Step: i=1, j=2
            // Step: i=2, j=1
            // </MultipleExpressions>
        }

        private static void Infinite()
        {
            // <InfiniteLoop>
            for ( ; ; )
            {
                // Body of the loop.
            }
            // </InfiniteLoop>
        }
    }
}