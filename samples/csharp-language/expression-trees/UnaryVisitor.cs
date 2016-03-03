using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    internal class UnaryVisitor : Visitor
    {
        private readonly UnaryExpression node;
        public UnaryVisitor(UnaryExpression node) : base(node)
        {
            this.node = node;
        }

        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This expression is a {NodeType} expression");
            var operandVisitor = Visitor.CreateFromExpression(node.Operand);
            Console.WriteLine($"The operand is:");
            operandVisitor.Visit(prefix + "\t");
        }
    }
}