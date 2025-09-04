using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    /// <summary>
    /// A visitor for lambda expressions.
    /// </summary>
    public class LambdaVisitor : Visitor
    {
        private readonly LambdaExpression node;

        /// <summary>
        /// Initializes a new instance of the <see cref="LambdaVisitor"/> class.
        /// </summary>
        /// <param name="node">The lambda expression to visit.</param>
        public LambdaVisitor(LambdaExpression node) : base(node)
        {
            this.node = node;
        }

        /// <summary>
        /// Visits the lambda expression.
        /// </summary>
        /// <param name="prefix">The prefix to use for the output.</param>
        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This expression is a {NodeType} expression type");
            Console.WriteLine($"{prefix}The name of the lambda is {((node.Name == null) ? "<null>" : node.Name)}");
            Console.WriteLine($"{prefix}The return type is {node.ReturnType.ToString()}");
            Console.WriteLine($"{prefix}The expression has {node.Parameters.Count} arguments. They are:");
            foreach (var argumentExpression in node.Parameters)
            {
                var argumentVisitor = Visitor.CreateFromExpression(argumentExpression);
                argumentVisitor.Visit(prefix + "\t");
            }
            Console.WriteLine($"{prefix}The expression body is:");
            var bodyVisitor = Visitor.CreateFromExpression(node.Body);
            bodyVisitor.Visit(prefix + "\t");
        }
    }
}