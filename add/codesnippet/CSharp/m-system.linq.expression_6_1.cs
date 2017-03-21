            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This statement creates an empty expression.
            DefaultExpression emptyExpr = Expression.Empty();

            // The empty expression can be used where an expression is expected, but no action is desired.
            // For example, you can use the empty expression as the last expression in the block expression.
            // In this case the block expression's return value is void.
            var emptyBlock = Expression.Block(emptyExpr);
