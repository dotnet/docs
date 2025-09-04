using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    /// <summary>
    /// A visitor for constant expressions.
    /// </summary>
    public class ConstantVisitor : Visitor
    {
        private readonly ConstantExpression node;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantVisitor"/> class.
        /// </summary>
        /// <param name="node">The constant expression to visit.</param>
        internal ConstantVisitor(ConstantExpression node) : base(node)
        {
            this.node = node;
        }

        /// <summary>
        /// Visits the constant expression.
        /// </summary>
        /// <param name="prefix">The prefix to use for the output.</param>
        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This is an {node.NodeType} expression type");
            Console.WriteLine($"{prefix}The type of the constant value is {node.Type}");
            Console.WriteLine($"{prefix}The value of the constant value is {node.Value}");
        }
    }
}