using System;

namespace lambda_expressions
{
    public static class ExpressionAndStatementLambdas
    {
        public static void Examples()
        {
            // <SnippetZeroParameters>
            Action line = () => Console.WriteLine();
            // </SnippetZeroParameters>

            // <SnippetTwoParameters>
            Func<int, int, bool> testForEquality = (x, y) => x == y;
            // </SnippetTwoParameters>

            // <SnippetExplicitlyTypedParameters>
            Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;
            // </SnippetExplicitlyTypedParameters>

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
        }
    }
}
