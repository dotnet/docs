using System;

namespace lambda_expressions
{
    public static class LambdasAndTuples
    {
        public static void Examples()
        {
            UnnamedTupleComponents();
            NamedTupleComponents();
        }

        private static void UnnamedTupleComponents()
        {
            // <SnippetWithoutComponentName>
            Func<(int, int, int), (int, int, int)> doubleThem = ns => (2 * ns.Item1, 2 * ns.Item2, 2 * ns.Item3);
            var numbers = (2, 3, 4);
            var doubledNumbers = doubleThem(numbers);
            Console.WriteLine($"The set {numbers} doubled: {doubledNumbers}");
            // Output:
            // The set (2, 3, 4) doubled: (4, 6, 8)
            // </SnippetWithoutComponentName>
        }

        private static void NamedTupleComponents()
        {
            // <SnippetWithComponentName>
            Func<(int n1, int n2, int n3), (int, int, int)> doubleThem = ns => (2 * ns.n1, 2 * ns.n2, 2 * ns.n3);
            var numbers = (2, 3, 4);
            var doubledNumbers = doubleThem(numbers);
            Console.WriteLine($"The set {numbers} doubled: {doubledNumbers}");
            // </SnippetWithComponentName>
        }
    }
}