            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression compares the values of its two arguments.
            // Both arguments must be of the same type.
            Expression greaterThanExpr = Expression.GreaterThan(
                Expression.Constant(42),
                Expression.Constant(45)
            );

            // Print out the expression.
            Console.WriteLine(greaterThanExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.    
            Console.WriteLine(
                Expression.Lambda<Func<bool>>(greaterThanExpr).Compile()());

            // This code example produces the following output:
            //
            // (42 > 45)
            // False