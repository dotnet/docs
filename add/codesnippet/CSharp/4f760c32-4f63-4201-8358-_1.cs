            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents a type convertion operation. 
            Expression convertExpr = Expression.Convert(
                                        Expression.Constant(5.5),
                                        typeof(Int16)
                                    );

            // Print out the expression.
            Console.WriteLine(convertExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(Expression.Lambda<Func<Int16>>(convertExpr).Compile()());

            // This code example produces the following output:
            //
            // Convert(5.5)
            // 5
