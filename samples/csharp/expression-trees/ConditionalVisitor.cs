using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    public class ConditionalVisitor : Visitor
    {
        private readonly ConditionalExpression node;
        public ConditionalVisitor(ConditionalExpression node) : base(node)
        {
            this.node = node;
        }

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