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
    }
}
