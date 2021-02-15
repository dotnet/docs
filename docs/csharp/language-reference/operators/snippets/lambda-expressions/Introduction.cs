using System;
using System.Linq;

namespace lambda_expressions
{
    public static class Introduction
    {
        public static void Examples()
        {
            LambdaAsDelegate();
            LambdaAsExpressionTree();
            LambdaArgument();
        }

        private static void LambdaAsDelegate()
        {
            // <SnippetDelegate>
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));
            // Output:
            // 25
            // </SnippetDelegate>
        }

        private static void LambdaAsExpressionTree()
        {
            // <SnippetExpressionTree>
            System.Linq.Expressions.Expression<Func<int, int>> e = x => x * x;
            Console.WriteLine(e);
            // Output:
            // x => (x * x)
            // </SnippetExpressionTree>
        }

        private static void LambdaArgument()
        {
            // <SnippetArgument>
            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);
            Console.WriteLine(string.Join(" ", squaredNumbers));
            // Output:
            // 4 9 16 25
            // </SnippetArgument>
        }

        private static void NonInvokableExpressionTree()
        {
            // <SnippetNonInvokableExpressionTree>
            Expression<Func<int, int>> expr = (int x) => x * x;

            // The following will not compile:
            // expr(3);
            // </SnippetNonInvokableExpressionTree>
        }

        private static void InspectExpressionTree()
        {
            // <SnippetInspectExpressionTree>
            Func<int, int> fn = (int x) => x * x;
            Console.WriteLine(expr.Parameters[0].Name);
            // Output:
            // x
            Console.WriteLine(expr.Body.NodeType);
            // Output: 
            // Multiply
            // </SnippetInspectExpressionTree>
        }
    }
}