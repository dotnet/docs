using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    public class ConstantVisitor : Visitor
    {
        private readonly ConstantExpression node;

        internal ConstantVisitor(ConstantExpression node) : base(node)
        {
            this.node = node;
        }

        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This is an {node.NodeType} expression type");
            Console.WriteLine($"{prefix}The type of the constant value is {node.Type}");
            Console.WriteLine($"{prefix}The value of the constant value is {node.Value}");
        }
    }
}