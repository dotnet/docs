using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    public class GoToVisitor : Visitor
    {
        private readonly GotoExpression node;
        public GoToVisitor(GotoExpression node) : base(node)
        {
            this.node = node;
        }

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