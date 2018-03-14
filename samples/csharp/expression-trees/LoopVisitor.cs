using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    public class LoopVisitor : Visitor
    {
        private readonly LoopExpression node;
        public LoopVisitor(LoopExpression node) : base(node)
        {
            this.node = node;
        }

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