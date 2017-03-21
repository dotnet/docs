            // Add the following directive to your file:
            // using System.Linq.Expressions; 

            // This expression represents a NOT operation.
            Expression notExpr = Expression.Not(Expression.Constant(true));

            Console.WriteLine(notExpr);

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Console.WriteLine(Expression.Lambda<Func<bool>>(notExpr).Compile()());

            // This code example produces the following output:
            //
            // Not(True)
            // False