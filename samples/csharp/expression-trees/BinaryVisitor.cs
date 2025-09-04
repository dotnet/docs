using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    /// <summary>
    /// A visitor for binary expressions.
    /// </summary>
    public class BinaryVisitor : Visitor
    {
        private readonly BinaryExpression node;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryVisitor"/> class.
        /// </summary>
        /// <param name="node">The binary expression to visit.</param>
        public BinaryVisitor(BinaryExpression node) : base(node)
        {
            this.node = node;
        }

        /// <summary>
        /// Visits the binary expression.
        /// </summary>
        /// <param name="prefix">The prefix to use for the output.</param>
        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This binary expression is a {NodeType} expression");
            var left = Visitor.CreateFromExpression(node.Left);
            Console.WriteLine($"{prefix}The Left argument is:");
            left.Visit(prefix + "\t");
            var right = Visitor.CreateFromExpression(node.Right);
            Console.WriteLine($"{prefix}The Right argument is:");
            right.Visit(prefix + "\t");
        }
    }
}