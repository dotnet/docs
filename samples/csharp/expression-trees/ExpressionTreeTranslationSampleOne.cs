using System;
using System.Linq.Expressions;

namespace ExpressionTreeSamples
{
    public class ExpressionTreeTranslationSampleOne : Sample
    {
        public override string Name { get; } = "Translation Expression Trees, Sample 1: Replacing Constant Nodes";
        
        public override void Run()
        {
            var one = Expression.Constant(1, typeof(int));
            var two = Expression.Constant(2, typeof(int));
            var addition = Expression.Add(one, two);
            var sum = ReplaceNodes(addition);
            var executableFunc = Expression.Lambda(sum);

            var func = (Func<int>)executableFunc.Compile();
            var answer = func();
            Console.WriteLine(answer);
       }
       
       private static Expression ReplaceNodes(Expression original)
       {
           if (original.NodeType == ExpressionType.Constant)
           {
               return Expression.Multiply(original, Expression.Constant(10));
           }
           else if (original.NodeType == ExpressionType.Add)
           {
               var binaryExpression = (BinaryExpression)original;
               return Expression.Add(
                   ReplaceNodes(binaryExpression.Left),
                   ReplaceNodes(binaryExpression.Right));
           }
           return original;
       }
    }
}
