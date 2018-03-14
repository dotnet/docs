using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    public abstract class Visitor
    {
        private readonly Expression node;

        protected Visitor(Expression node)
        {
            this.node = node;
        }

        public abstract void Visit(string prefix);

        public ExpressionType NodeType => this.node.NodeType;
        public static Visitor CreateFromExpression(Expression node)
        {
            switch(node.NodeType)
            {
                case ExpressionType.Constant:
                    return new ConstantVisitor((ConstantExpression)node);
                case ExpressionType.Lambda:
                    return new LambdaVisitor((LambdaExpression)node);
                case ExpressionType.Parameter:
                    return new ParameterVisitor((ParameterExpression)node);
                // Lots of Binary Expression Types:
                case ExpressionType.Add:
                case ExpressionType.Equal:
                case ExpressionType.Multiply:
                case ExpressionType.GreaterThan:
                case ExpressionType.Assign:
                    return new BinaryVisitor((BinaryExpression)node);
                case ExpressionType.Conditional:
                    return new ConditionalVisitor((ConditionalExpression)node);
                case ExpressionType.Call:
                    return new MethodCallVisitor((MethodCallExpression)node);
                case ExpressionType.Block:
                    return new BlockVisitor((BlockExpression)node);
                case ExpressionType.Loop:
                    return new LoopVisitor((LoopExpression)node);
                case ExpressionType.PostDecrementAssign:
                    return new UnaryVisitor((UnaryExpression)node);
                case ExpressionType.Goto:
                    return new GoToVisitor((GotoExpression)node);
                default:
                    Console.Error.WriteLine($"Node not processed yet: {node.NodeType}");
                    return default(Visitor);
            }
        }
    }
}
