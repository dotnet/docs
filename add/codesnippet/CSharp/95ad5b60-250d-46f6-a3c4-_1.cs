            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression subtracts the second argument 
            // from the first argument.
            // Both arguments must be of the same type.
            Expression subtractExpr = Expression.Subtract(
                Expression.Constant(12),
                Expression.Constant(3)
            );

            // Print out the expression.
            Console.WriteLine(subtractExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.            
            Console.WriteLine(Expression.Lambda<Func<int>>(subtractExpr).Compile().Invoke());

            // This code example produces the following output:
            //
            // (12 - 3)
            // 9