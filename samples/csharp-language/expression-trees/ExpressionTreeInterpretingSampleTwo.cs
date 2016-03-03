using System;
using System.Linq.Expressions;

namespace ExpressionTreeSamples
{
    public class ExpressionTreeInterpretingSampleTwo : Sample
    {
        public override string Name { get; } = "Interpreting Expression Trees, Sample 2: Understanding Binary Expression Nodes";
        
        public override void Run()
        {
            Expression<Func<int, int, int>> addition = (a, b) => a + b;

            Console.WriteLine($"This expression is a {addition.NodeType} expression type");
            Console.WriteLine($"The name of the lambda is {((addition.Name == null) ? "<null>" : addition.Name)}");
            Console.WriteLine($"The return type is {addition.ReturnType.ToString()}");
            Console.WriteLine($"The expression has {addition.Parameters.Count} arguments. They are:");
            foreach (var argumentExpression in addition.Parameters)
            {
                Console.WriteLine($"\tParameter Type: {argumentExpression.Type.ToString()}, Name: {argumentExpression.Name}");
            }

            var additionBody = (BinaryExpression)addition.Body;
            Console.WriteLine($"The body is a {additionBody.NodeType} expression");
            Console.WriteLine($"The left side is a {additionBody.Left.NodeType} expression");
            var left = (ParameterExpression)additionBody.Left;
            Console.WriteLine($"\tParameter Type: {left.Type.ToString()}, Name: {left.Name}");
            Console.WriteLine($"The right side is a {additionBody.Right.NodeType} expression");
            var right = (ParameterExpression)additionBody.Right;
            Console.WriteLine($"\tParameter Type: {right.Type.ToString()}, Name: {right.Name}");
        }
    }
}