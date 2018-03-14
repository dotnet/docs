using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    public class ParameterVisitor : Visitor
    {
        private readonly ParameterExpression node;
        public ParameterVisitor(ParameterExpression node) : base(node)
        {
            this.node = node;
        }

        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This is an {NodeType} expression type");
            Console.WriteLine($"{prefix}Type: {node.Type.ToString()}, Name: {node.Name}, ByRef: {node.IsByRef}");
        }
    }
}