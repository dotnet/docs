using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    /// <summary>
    /// A visitor for parameter expressions.
    /// </summary>
    public class ParameterVisitor : Visitor
    {
        private readonly ParameterExpression node;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterVisitor"/> class.
        /// </summary>
        /// <param name="node">The parameter expression to visit.</param>
        public ParameterVisitor(ParameterExpression node) : base(node)
        {
            this.node = node;
        }

        /// <summary>
        /// Visits the parameter expression.
        /// </summary>
        /// <param name="prefix">The prefix to use for the output.</param>
        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This is an {NodeType} expression type");
            Console.WriteLine($"{prefix}Type: {node.Type.ToString()}, Name: {node.Name}, ByRef: {node.IsByRef}");
        }
    }
}