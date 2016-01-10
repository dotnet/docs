using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ExpressionVisitor;

namespace ExpressionTreeSamples
{
    public class ExpressionTreeBuildingSampleOne : Sample
    {
        public override string Name { get; } = "Building Expression Trees, Sample 1: Creating a statement based tree";
        
        public override void Run()
        {
             var lambda = Expression.Lambda(
                Expression.Add(
                    Expression.Constant(1, typeof(int)),
                    Expression.Constant(2, typeof(int))
                )
            );

            var xParameter = Expression.Parameter(typeof(double), "x");
            var yParameter = Expression.Parameter(typeof(double), "y");

            var xSquared = Expression.Multiply(xParameter, xParameter);
            var ySquared = Expression.Multiply(yParameter, yParameter);
            var sum = Expression.Add(xSquared, ySquared);

            Expression<Func<double, double>> sqrt = (x) => Math.Sqrt(x);
            var methodCall = sqrt.Body as MethodCallExpression;
            var distance = methodCall.Update(default(Expression), new List<Expression> { sum });

            var distanceLambda = Expression.Lambda(
                distance,
                xParameter,
                yParameter);

            var visitor = Visitor.CreateFromExpression(distanceLambda);
            visitor.Visit("");
       }
    }
}
