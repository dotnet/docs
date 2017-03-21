            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression perfroms a logical OR operation
            // on its two arguments. Both arguments must be of the same type,
            // which can be boolean or integer.             
            Expression orExpr = Expression.Or(
                Expression.Constant(true),
                Expression.Constant(false)
            );

            // Print out the expression.
            Console.WriteLine(orExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.       
            Console.WriteLine(Expression.Lambda<Func<bool>>(orExpr).Compile()());

            // This code example produces the following output:
            //
            // (True Or False)
            // True