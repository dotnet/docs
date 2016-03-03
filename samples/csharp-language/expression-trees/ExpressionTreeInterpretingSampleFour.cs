using System;
using System.Linq;
using System.Linq.Expressions;

using ExpressionVisitor;

namespace ExpressionTreeSamples
{
    public class ExpressionTreeInterpretingSampleFour : Sample
    {
        public override string Name { get; } = "Interpreting Expression Trees, Sample 4: Method Calls and Conditionals";
        
        public override void Run()
        {
            Expression<Func<int, int>> factorial = (n) =>
                n == 0 ?
                1 :
                Enumerable.Range(1, n).Aggregate((product, factor) => product * factor);

            var visitor = Visitor.CreateFromExpression(factorial);
            visitor.Visit("");
        }
    }
}
