using System;
using System.Linq.Expressions;

namespace ExpressionTreeSamples
{
    public class ExpressionTreeInterpretingSampleOne : Sample
    {
        public override string Name { get; } = "Interpreting Expression Trees, Sample 1: Understanding Constant Nodes";
        
        public override void Run()
        {
            var constant = Expression.Constant(24, typeof(int));

            Console.WriteLine($"This is an {constant.NodeType} expression type");
            Console.WriteLine($"The type of the constant value is {constant.Type}");
            Console.WriteLine($"The value of the constant value is {constant.Value}");
        }
    }
}