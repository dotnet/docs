using System;
using System.Collections.Generic;
using System.Linq;

namespace lambda_expressions
{
    public static class LambdasWithQueryMethods
    {
        public static void Examples()
        {
            FuncExample();
            CountExample();
            TakeWhileExample();
            TakeWhileWithIndexExample();
            QueryExample();
        }

        private static void FuncExample()
        {
            // <SnippetFunc>
            Func<int, bool> equalsFive = x => x == 5;
            bool result = equalsFive(4);
            Console.WriteLine(result);   // False
            // </SnippetFunc>
        }

        private static void CountExample()
        {
            // <SnippetCount>
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int oddNumbers = numbers.Count(n => n % 2 == 1);
            Console.WriteLine($"There are {oddNumbers} odd numbers in {string.Join(" ", numbers)}");
            // </SnippetCount>
        }

        private static void TakeWhileExample()
        {
            // <SnippetTakeWhile>
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var firstNumbersLessThanSix = numbers.TakeWhile(n => n < 6);
            Console.WriteLine(string.Join(" ", firstNumbersLessThanSix));
            // Output:
            // 5 4 1 3
            // </SnippetTakeWhile>
        }

        private static void TakeWhileWithIndexExample()
        {
            // <SnippetTakeWhileWithIndex>
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);
            Console.WriteLine(string.Join(" ", firstSmallNumbers));
            // Output:
            // 5 4
            // </SnippetTakeWhileWithIndex>
        }

        private static void QueryExample()
        {
            // <Query>
            var numberSets = new List<int[]>
            {
                new[] { 1, 2, 3, 4, 5 },
                new[] { 0, 0, 0 },
                new[] { 9, 8 },
                new[] { 1, 0, 1, 0, 1, 0, 1, 0 }
            };

            var setsWithManyPositives = 
                from numberSet in numberSets
                where numberSet.Count(n => n > 0) > 3
                select numberSet;

            foreach (var numberSet in setsWithManyPositives)
            {
                Console.WriteLine(string.Join(" ", numberSet));
            }
            // Output:
            // 1 2 3 4 5
            // 1 0 1 0 1 0 1 0
            // </Query>
        }
    }
}