using System;
using System.Linq.Expressions;

namespace ExecutingExprTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet1>
            // The expression tree to execute.
            BinaryExpression be = Expression.Power(Expression.Constant(2D), Expression.Constant(3D));

            // Create a lambda expression.
            Expression<Func<double>> le = Expression.Lambda<Func<double>>(be);

            // Compile the lambda expression.
            Func<double> compiledExpression = le.Compile();

            // Execute the lambda expression.
            double result = compiledExpression();

            // Display the result.
            Console.WriteLine(result);

            // This code produces the following output:
            // 8

            // </Snippet1>
        }
    }
}
