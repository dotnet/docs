            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression perfroms a logical OR operation
            // on its two arguments, but if the first argument is true,
            // then the second arument is not evaluated.
            // Both arguments must be of the boolean type.
            Expression orElseExpr = Expression.OrElse(
                Expression.Constant(false),
                Expression.Constant(true)
            );

            // Print out the expression.
            Console.WriteLine(orElseExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it. 
            Console.WriteLine(Expression.Lambda<Func<bool>>(orElseExpr).Compile().Invoke());

            // This code example produces the following output:
            //
            // (False OrElse True)
            // True
