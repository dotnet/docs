using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    /// <summary>
    /// A visitor for goto expressions.
    /// </summary>
    public class GoToVisitor : Visitor
    {
        private readonly GotoExpression node;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoToVisitor"/> class.
        /// </summary>
        /// <param name="node">The goto expression to visit.</param>
        public GoToVisitor(GotoExpression node) : base(node)
        {
            this.node = node;
        }

        /// <summary>
        /// Visits the goto expression.
        /// </summary>
        /// <param name="prefix">The prefix to use for the output.</param>
        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This expression is a {NodeType} expression");
            Console.WriteLine($"{prefix}THe kind of GoTo is: {node.Kind}");

            Console.WriteLine($"{prefix}The target is {node.Target.Name}");
            Console.WriteLine($"{prefix}The value of the goto is:");
            var visitor = Visitor.CreateFromExpression(node.Value);
            visitor.Visit(prefix + "\t");
        }
    }
}