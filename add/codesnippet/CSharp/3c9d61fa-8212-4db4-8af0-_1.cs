            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents an increment operation. 
            double num = 5.5;
            Expression incrementExpr = Expression.Increment(
                                        Expression.Constant(num)
                                    );


            // Print out the expression.
            Console.WriteLine(incrementExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(Expression.Lambda<Func<double>>(incrementExpr).Compile()());

            // The value of the variable did not change,
            // because the expression is functional.
            Console.WriteLine("object: " + num);

            // This code example produces the following output:
            //
            // Increment(5.5)
            // 6.5
            // object: 5.5