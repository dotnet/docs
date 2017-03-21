            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            double num = 5.5;

            // This expression represents a decrement operation 
            // that subtracts 1 from a value. 
            Expression decrementExpr = Expression.Decrement(
                                        Expression.Constant(num)
                                    );

            // Print expression.
            Console.WriteLine(decrementExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(
                Expression.Lambda<Func<double>>(decrementExpr).Compile()());

            // The value of the variable did not change,
            // because the expression is functional.
            Console.WriteLine("object: " + num);

            // This code example produces the following output:
            //
            // Decrement(5.5)
            // 4.5
            // object: 5.5