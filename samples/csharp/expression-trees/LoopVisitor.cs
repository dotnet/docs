using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    /// <summary>
    /// A visitor for loop expressions.
    /// </summary>
    public class LoopVisitor : Visitor
    {
        private readonly LoopExpression node;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoopVisitor"/> class.
        /// </summary>
        /// <param name="node">The loop expression to visit.</param>
        public LoopVisitor(LoopExpression node) : base(node)
        {
            this.node = node;
        }

        /// <summary>
        /// Visits the loop expression.
        /// </summary>
        /// <param name="prefix">The prefix to use for the output.</param>
        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This expression is a {NodeType} expression");

            Console.WriteLine($"{prefix}Continue Target is: {node.ContinueLabel?.Name ?? "<null>"}");
            Console.WriteLine($"{prefix}Break Target is: {node.BreakLabel.Name ?? "<unnamed>"}");

            Console.WriteLine($"{prefix}Body is:");
            var bodyVisitor = Visitor.CreateFromExpression(node.Body);
            bodyVisitor.Visit(prefix+"\t");
        }
    }
}