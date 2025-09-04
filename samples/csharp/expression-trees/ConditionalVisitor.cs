using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    /// <summary>
    /// A visitor for conditional expressions.
    /// </summary>
    public class ConditionalVisitor : Visitor
    {
        private readonly ConditionalExpression node;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionalVisitor"/> class.
        /// </summary>
        /// <param name="node">The conditional expression to visit.</param>
        public ConditionalVisitor(ConditionalExpression node) : base(node)
        {
            this.node = node;
        }

        /// <summary>
        /// Visits the conditional expression.
        /// </summary>
        /// <param name="prefix">The prefix to use for the output.</param>
        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This expression is a {NodeType} expression");
            var testVisitor = Visitor.CreateFromExpression(node.Test);
            Console.WriteLine($"{prefix}The Test for this expression is:");
            testVisitor.Visit(prefix + "\t");
            var trueVisitor = Visitor.CreateFromExpression(node.IfTrue);
            Console.WriteLine($"{prefix}The True clause for this expression is:");
            trueVisitor.Visit(prefix + "\t");
            var falseVisitor = Visitor.CreateFromExpression(node.IfFalse);
            Console.WriteLine($"{prefix}The False clause for this expression is:");
            falseVisitor.Visit(prefix + "\t");
        }
    }
}