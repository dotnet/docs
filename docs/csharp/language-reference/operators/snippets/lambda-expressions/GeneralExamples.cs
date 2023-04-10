using System;

namespace lambda_expressions
{
    public static class GeneralExamples
    {
        public static void Examples()
        {
            // <SnippetZeroParameters>
            Action line = () => Console.WriteLine();
            // </SnippetZeroParameters>

            // <SnippetOneParameter>
            Func<double, double> cube = x => x * x * x;
            // </SnippetOneParameter>

            // <SnippetTwoParameters>
            Func<int, int, bool> testForEquality = (x, y) => x == y;
            // </SnippetTwoParameters>

            // <SnippetExplicitlyTypedParameters>
            Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;
            // </SnippetExplicitlyTypedParameters>

            // <SnippetDiscards>
            Func<int, int, int> constant = (_, _) => 42;
            // </SnippetDiscards>

            // <SnippetStatementLambda>
            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };
            greet("World");
            // Output:
            // Hello World!
            // </SnippetStatementLambda>

            // <SnippetStatic>
            Func<double, double> square = static x => x * x;
            // </SnippetStatic>
        }

        public static void DefaultParmExamples()
        {
            // <SnippetDefaultParameters>
            var IncrementBy = (int source, int increment = 1) => source + increment;

            Console.WriteLine(IncrementBy(5)); // 6
            Console.WriteLine(IncrementBy(5, 2)); // 7
            // </SnippetDefaultParameters>

            // <SnippetParamsArray>
            var sum = (params int[] values) =>
            {
                int sum = 0;
                foreach (var value in values) 
                    sum += value;
                
                return sum;
            };

            var empty = sum();
            Console.WriteLine(empty); // 0

            var sequence = new[] { 1, 2, 3, 4, 5 };
            var total = sum(sequence);
            Console.WriteLine(total); // 15
            // </SnippetParamsArray>
        }

        // <DelegateDeclarations>
        delegate int IncrementByDelegate(int source, int increment = 1);
        delegate int SumDelegate(params int[] values);
        // </DelegateDeclarations>

    }
}
