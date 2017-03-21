            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression adds the values of its two arguments.
            // Both arguments must be of the same type.
            Expression sumExpr = Expression.Add(
                Expression.Constant(1),
                Expression.Constant(2)
            );

            // Print out the expression.
            Console.WriteLine(sumExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.            
            Console.WriteLine(Expression.Lambda<Func<int>>(sumExpr).Compile()());

            // This code example produces the following output:
            //
            // (1 + 2)
            // 3