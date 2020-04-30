using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace keywords
{
    public static class IterationKeywordsExamples
    {
        public static async Task Examples()
        {
            ForeachWithIEnumerable();
            IterateSpanExample.Main();
            ForeachRefExample.Main();
            await AwaitForeachExample();
            WhileLoopExample();
            DoLoopExample();
            TypicalForLoopExample();
            ForLoopWithSeveralStatementsInSectionsExample();
        }

        private static async Task AwaitForeachExample()
        {
            // <SnippetAwaitForeach>
            await foreach (var item in GenerateSequenceAsync())
            {
                Console.WriteLine(item);
            }
            // </SnippetAwaitForeach>

        }

        private static async IAsyncEnumerable<int> GenerateSequenceAsync()
        {
            for(int i = 0; i < 40; i++)
            {
                if (i % 10 == 0)
                    await Task.Delay(2000);
                yield return i;
            }
        }

        private static void ForeachWithIEnumerable()
        {
            // <Snippet1>
            var fibNumbers = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13 };
            int count = 0;
            foreach (int element in fibNumbers)
            {
                count++;
                Console.WriteLine($"Element #{count}: {element}");
            }
            Console.WriteLine($"Number of elements: {count}");
            // </Snippet1>
        }

        private static void WhileLoopExample()
        {
            // <Snippet3>
            int n = 0;
            while (n < 5)
            {
                Console.WriteLine(n);
                n++;
            }
            // </Snippet3>
        }

        private static void DoLoopExample()
        {
            // <Snippet4>
            int n = 0;
            do
            {
                Console.WriteLine(n);
                n++;
            } while (n < 5);
            // </Snippet4>
        }

        private static void TypicalForLoopExample()
        {
            // <Snippet5>
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
            }
            // </Snippet5>
        }

        private static void ForLoopWithSeveralStatementsInSectionsExample()
        {
            // <Snippet6>
            int i;
            int j = 10;
            for (i = 0, Console.WriteLine($"Start: i={i}, j={j}"); i < j; i++, j--, Console.WriteLine($"Step: i={i}, j={j}"))
            {
                // Body of the loop.
            }
            // </Snippet6>
        }

        private static void InfiniteForLoopExample()
        {
            // <Snippet7>
            for ( ; ; )
            {
                // Body of the loop.
            }
            // </Snippet7>
        }

        // We want snippets to be interactive.
        // To make snippets with Span<T> (which is ref struct) interactive,
        // the example code must be the part of a non-async Main method and
        // the complete program source must be included into the snippet.
        // Thus, such snippets below.

        // <Snippet2>
        public class IterateSpanExample
        {
            public static void Main()
            {
                Span<int> numbers = new int[] { 3, 14, 15, 92, 6 };
                foreach (int number in numbers)
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine();
            }
        }
        // </Snippet2>

        // <SnippetRefSpan>
        public class ForeachRefExample
        {
            public static void Main()
            {
                Span<int> storage = stackalloc int[10];
                int num = 0;
                foreach (ref int item in storage)
                {
                    item = num++;
                }

                foreach (ref readonly var item in storage)
                {
                    Console.Write($"{item} ");
                }
                // Output:
                // 0 1 2 3 4 5 6 7 8 9
            }
        }
        // </SnippetRefSpan>
    }
}
