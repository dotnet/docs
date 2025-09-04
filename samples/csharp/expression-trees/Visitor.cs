using System;
using System.Linq.Expressions;

namespace ExpressionVisitor
{
    /// <summary>
    /// The base class for all expression tree visitors.
    /// </summary>
    public abstract class Visitor
    {
        private readonly Expression node;

        /// <summary>
        /// Initializes a new instance of the <see cref="Visitor"/> class.
        /// </summary>
        /// <param name="node">The expression to visit.</param>
        protected Visitor(Expression node)
        {
            this.node = node;
        }

        /// <summary>
        /// Visits the expression.
        /// </summary>
        /// <param name="prefix">The prefix to use for the output.</param>
        public abstract void Visit(string prefix);

        /// <summary>
        /// Gets the node type of the expression.
        /// </summary>
        public ExpressionType NodeType => this.node.NodeType;

        /// <summary>
        /// Creates a visitor for the specified expression.
        /// </summary>
        /// <param name="node">The expression to create a visitor for.</param>
        /// <returns>A visitor for the specified expression.</returns>
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
