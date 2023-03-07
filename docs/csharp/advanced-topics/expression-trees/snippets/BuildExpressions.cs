using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeExample;
public static class BuildExpressions
{
    public static void AddExpression()
    {
        // <AddExpression>
        Expression<Func<int>> sum = () => 1 + 2;
        // </AddExpression>
    }

    public static void BuildAddExpression()
    {
        // <BuildConstantLeaves>
        var one = Expression.Constant(1, typeof(int));
        var two = Expression.Constant(2, typeof(int));
        // </BuildConstantLeaves>

        // <BuildAdditionNode>
        var addition = Expression.Add(one, two);
        // </BuildAdditionNode>

        // <BuildLambdaExpression>
        var lambda = Expression.Lambda(addition);
        // </BuildLambdaExpression>

        // <SingleExpression>
        var lambda2 = Expression.Lambda(
            Expression.Add(
                Expression.Constant(1, typeof(int)),
                Expression.Constant(2, typeof(int))
            )
        );
        // </SingleExpression>
    }

    public static void SquareRootLambda()
    {
        // <SquareRootLambda>
        Expression<Func<double, double, double>> distanceCalc =
            (x, y) => Math.Sqrt(x * x + y * y);
        // </SquareRootLambda>
    }

    public static void BuildSquareRoot()
    {
        // <BuildParameters>
        var xParameter = Expression.Parameter(typeof(double), "x");
        var yParameter = Expression.Parameter(typeof(double), "y");
        // </BuildParameters>

        // <BuildSumOfSquare>
        var xSquared = Expression.Multiply(xParameter, xParameter);
        var ySquared = Expression.Multiply(yParameter, yParameter);
        var sum = Expression.Add(xSquared, ySquared);
        // </BuildSumOfSquare>

        // <DistanceMethod>
        var sqrtMethod = typeof(Math).GetMethod("Sqrt", new[] { typeof(double) }) ?? throw new InvalidOperationException("Math.Sqrt not found!");
        var distance = Expression.Call(sqrtMethod, sum);
        // </DistanceMethod>

        // <CreateLambda>
        var distanceLambda = Expression.Lambda(
            distance,
            xParameter,
            yParameter);
        // </CreateLambda>
    }

    public static void FactorialFunc()
    {
        // <FactorialFunc>
        Func<int, int> factorialFunc = (n) =>
        {
            var res = 1;
            while (n > 1)
            {
                res = res * n;
                n--;
            }
            return res;
        };
        // </FactorialFunc>
    }

    public static void BuildFactorialFunc()
    {
        // <BuildFactorialFunc>
        var nArgument = Expression.Parameter(typeof(int), "n");
        var result = Expression.Variable(typeof(int), "result");

        // Creating a label that represents the return value
        LabelTarget label = Expression.Label(typeof(int));

        var initializeResult = Expression.Assign(result, Expression.Constant(1));

        // This is the inner block that performs the multiplication,
        // and decrements the value of 'n'
        var block = Expression.Block(
            Expression.Assign(result,
                Expression.Multiply(result, nArgument)),
            Expression.PostDecrementAssign(nArgument)
        );

        // Creating a method body.
        BlockExpression body = Expression.Block(
            new[] { result },
            initializeResult,
            Expression.Loop(
                Expression.IfThenElse(
                    Expression.GreaterThan(nArgument, Expression.Constant(1)),
                    block,
                    Expression.Break(label, result)
                ),
                label
            )
        );
        // </BuildFactorialFunc>
    }
}
