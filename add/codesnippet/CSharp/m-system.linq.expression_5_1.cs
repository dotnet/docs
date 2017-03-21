            // Add the following directive to your file:
            // using System.Linq.Expressions; 

            // This expression represents a negation operation.
            Expression negateExpr = Expression.Negate(Expression.Constant(5));

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Console.WriteLine(Expression.Lambda<Func<int>>(negateExpr).Compile()());

            // This code example produces the following output:
            //
            // -5
