using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    /// <summary>
    /// A visitor for block expressions.
    /// </summary>
    public class BlockVisitor : Visitor
    {
        private readonly BlockExpression node;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockVisitor"/> class.
        /// </summary>
        /// <param name="node">The block expression to visit.</param>
        public BlockVisitor(BlockExpression node) : base(node)
        {
            this.node = node;
        }

        /// <summary>
        /// Visits the block expression.
        /// </summary>
        /// <param name="prefix">The prefix to use for the output.</param>
        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This expression is a {NodeType} expression");

            var resultVisitor = Visitor.CreateFromExpression(node.Result);
            Console.WriteLine($"{prefix}Result from Block: ");
            resultVisitor.Visit(prefix + "\t");
            Console.WriteLine($"{prefix}Variables:");
            foreach (var variable in node.Variables)
            {
                var variablesVisitor = Visitor.CreateFromExpression(variable);
                variablesVisitor.Visit(prefix + "\t");
            }

            Console.WriteLine($"{prefix}Block Statements:");
            foreach(var statement in node.Expressions)
            {
                var statementVisitor = Visitor.CreateFromExpression(statement);
                statementVisitor.Visit(prefix+"\t");
            }
        }
    }
}