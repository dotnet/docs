using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    /// <summary>
    /// A visitor for method call expressions.
    /// </summary>
    public class MethodCallVisitor : Visitor
    {
        private readonly MethodCallExpression node;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodCallVisitor"/> class.
        /// </summary>
        /// <param name="node">The method call expression to visit.</param>
        public MethodCallVisitor(MethodCallExpression node) : base(node)
        {
            this.node = node;
        }

        /// <summary>
        /// Visits the method call expression.
        /// </summary>
        /// <param name="prefix">The prefix to use for the output.</param>
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