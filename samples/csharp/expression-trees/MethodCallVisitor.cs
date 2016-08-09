using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    public class MethodCallVisitor : Visitor
    {
        private readonly MethodCallExpression node;
        public MethodCallVisitor(MethodCallExpression node) : base(node)
        {
            this.node = node;
        }

        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This expression is a {NodeType} expression");
            if (node.Object == null)
                Console.WriteLine($"{prefix}This is a static method call");
            else
            {
                Console.WriteLine($"{prefix}The receiver (this) is:");
                var receiverVisitor = Visitor.CreateFromExpression(node.Object);
                receiverVisitor.Visit(prefix + "\t");
            }

            var methodInfo = node.Method;
            Console.WriteLine($"{prefix}The method name is {methodInfo.DeclaringType}.{methodInfo.Name}");
            Console.WriteLine($"{prefix}The return type is {methodInfo.ReturnType}");
            // There is more here, like generic arguments, and so on.
            Console.WriteLine($"{prefix}The Arguments are:");
            foreach(var arg in node.Arguments)
            {
                var argVisitor = Visitor.CreateFromExpression(arg);
                argVisitor.Visit(prefix + "\t");
            }
        }
    }
}