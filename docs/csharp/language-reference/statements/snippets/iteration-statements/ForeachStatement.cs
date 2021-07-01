using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IterationStatements
{
    public static class ForeachStatement
    {
        public static void Examples()
        {
            ForeachWithIEnumerable();
            ForeachWithSpan();
            RefIterationVariable();
        }

        private static void ForeachWithIEnumerable()
        {
            // <WithIEnumerable>
            var fibNumbers = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13 };
            foreach (int element in fibNumbers)
            {
                Console.Write($"{element} ");
            }
            // Output:
            // 0 1 1 2 3 5 8 13
            // </WithIEnumerable>
            Console.WriteLine();
        }

        private static void ForeachWithSpan()
        {
            // <WithSpan>
            Span<int> numbers = new int[] { 3, 14, 15, 92, 6 };
            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }
            // Output:
            // 3 14 15 92 6
            // </WithSpan>
            Console.WriteLine();
        }

        private static void RefIterationVariable()
        {
            // <RefIterationVariable>
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
            // </RefIterationVariable>
            Console.WriteLine();
        }

        private static async Task AwaitForeachExample()
        {
            // <AwaitForeach>
            await foreach (var item in GenerateSequenceAsync())
            {
                Console.WriteLine(item);
            }
            // </AwaitForeach>

        }

        private static async IAsyncEnumerable<int> GenerateSequenceAsync()
        {
            for (int i = 0; i < 40; i++)
            {
                if (i % 10 == 0)
                {
                    await Task.Delay(2000);
                }
                yield return i;
            }
        }
    }
}