using System;
using System.Linq.Expressions;

using ExpressionVisitor;

namespace ExpressionTreeSamples
{
    public class ExpressionTreeInterpretingSampleThree : Sample
    {
        public override string Name { get; } = "Interpreting Expression Trees, Sample 3: Building a General Visitor";
        
        public override void Run()
        {
            Expression<Func<int, int, int>> addition = (a, b) => a + b;
            var visitor = Visitor.CreateFromExpression(addition);

            visitor.Visit("");

            Expression<Func<int, int>> sum = (a) => 1 + a + 3 + 4;

            visitor = Visitor.CreateFromExpression(sum);
            visitor.Visit("");

            Expression<Func<int, int, int>> sum3 = (a, b) => (1 + a) + (3 + b);

            visitor = Visitor.CreateFromExpression(sum3);
            visitor.Visit("");
        }
    }
}