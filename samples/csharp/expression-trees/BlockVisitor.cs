using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    public class BlockVisitor : Visitor
    {
        private readonly BlockExpression node;
        public BlockVisitor(BlockExpression node) : base(node)
        {
            this.node = node;
        }

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