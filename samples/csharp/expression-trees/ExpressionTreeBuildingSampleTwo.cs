using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ExpressionVisitor;

namespace ExpressionTreeSamples
{
    public class ExpressionTreeBuildingSampleTwo : Sample
    {
        public override string Name { get; } = "Building Expression Trees, Sample 2: Building Loops and Conditionals";
        
        public override void Run()
        {
            // This code builds the equivalent of:
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

            var factorial = Expression.Lambda(body, nArgument);

            // Compile and run an expression tree.
            var func = (Func<int, int>)factorial.Compile();

            Console.WriteLine(func(5));
            var visitor = Visitor.CreateFromExpression(factorial);
            visitor.Visit("");
       }
    }
}
