using System;
using System.Linq.Expressions;

namespace ModifyingExprTrees
{
    // <Snippet2>
    public class AndAlsoModifier : ExpressionVisitor
    {
        public Expression Modify(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            if (b.NodeType == ExpressionType.AndAlso)
            {
                Expression left = this.Visit(b.Left);
                Expression right = this.Visit(b.Right);

                // Make this binary expression an OrElse operation instead of an AndAlso operation.
                return Expression.MakeBinary(ExpressionType.OrElse, left, right, b.IsLiftedToNull, b.Method);
            }

            return base.VisitBinary(b);
        }
    }
    // </Snippet2>
}
