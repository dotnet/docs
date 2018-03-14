using System;
using System.Linq.Expressions;

namespace ExpressionTreeSamples
{
    public class ExpressionTreeExecutionSampleOne : Sample
    {
        public override string Name { get; } = "Executing Expression Trees, Sample 1";
        
        public override void Run()
        {
            Expression<Func<int>> add = () => 1 + 2;
            var func = add.Compile();
            var answer = func();
            Console.WriteLine(answer);
        }
    }
}