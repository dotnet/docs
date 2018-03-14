using System;
using System.Linq.Expressions;

namespace ExpressionTreeSamples
{
    public class ExpressionTreeClassesSampleTwo : Sample
    {
        public override string Name { get; } = "Expression Tree Classes, Sample 2";
        
        public override void Run()
        {
            var one = Expression.Constant(1, typeof(int));
            var two = Expression.Constant(2, typeof(int));
            var addition = Expression.Add(one, two);
            var lambda = Expression.Lambda(addition);
            
            var func = (Func<int>)lambda.Compile();
            Console.WriteLine(func());
        }
    }
}