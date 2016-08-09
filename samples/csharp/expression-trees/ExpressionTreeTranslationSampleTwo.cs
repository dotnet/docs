using System;
using System.Linq.Expressions;

namespace ExpressionTreeSamples
{
    public class ExpressionTreeTranslationSampleTwo : Sample
    {
        public override string Name { get; } = "Translation Expression Trees, Sample 2: Computing the sum of an addition tree";
        
        public override void Run()
        {
            var one = Expression.Constant(1, typeof(int));
            var two = Expression.Constant(2, typeof(int));
            var three = Expression.Constant(3, typeof(int));
            var four = Expression.Constant(4, typeof(int));
            var addition = Expression.Add(one, two);
            var add2 = Expression.Add(three, four);
            var sum = Expression.Add(addition, add2);

            // Declare the delegate, so we can call it 
            // from itself recursively:
            Func<Expression, int> aggregate = null;
            // Aggregate, return constants, or the sum of the left and right operand.
            // Major simplification: Assume every binary expression is an addition.
            aggregate = (exp) =>
                exp.NodeType == ExpressionType.Constant ?
                (int)((ConstantExpression)exp).Value :
                aggregate(((BinaryExpression)exp).Left) + aggregate(((BinaryExpression)exp).Right);

            var theSum = aggregate(sum);
            Console.WriteLine(theSum);
       }
    }
}
