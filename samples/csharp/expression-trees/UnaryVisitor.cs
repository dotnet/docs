using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    /// <summary>
    /// A visitor for unary expressions.
    /// </summary>
    internal class UnaryVisitor : Visitor
    {
        private readonly UnaryExpression node;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnaryVisitor"/> class.
        /// </summary>
        /// <param name="node">The unary expression to visit.</param>
        public UnaryVisitor(UnaryExpression node) : base(node)
        {
            this.node = node;
        }

        /// <summary>
        /// Visits the unary expression.
        /// </summary>
        /// <param name="prefix">The prefix to use for the output.</param>
        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This expression is a {NodeType} expression");
            var operandVisitor = Visitor.CreateFromExpression(node.Operand);
            Console.WriteLine($"The operand is:");
            operandVisitor.Visit(prefix + "\t");
        }
    }
}