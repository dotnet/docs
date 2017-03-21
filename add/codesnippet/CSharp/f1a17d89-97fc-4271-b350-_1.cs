            // Add the following directive to the file.
            // using System.Linq.Expressions;  

            // A TryExpression object that has a catch statement and a finally statement.
            // The return types of the try block and all catch blocks must be the same.
            TryExpression tryCatchExpr =
                Expression.TryCatchFinally(
                    Expression.Block(
                        Expression.Throw(Expression.Constant(new DivideByZeroException())),
                        Expression.Constant("Try block")
                    ),
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("Finally block")),
                    Expression.Catch(
                        typeof(DivideByZeroException),
                        Expression.Constant("Catch block")
                    )
                );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            // If the exception is caught, 
            // the result of the TryExpression is the last statement 
            // of the corresponding catch statement.
            Console.WriteLine(Expression.Lambda<Func<string>>(tryCatchExpr).Compile()());

            // This code example produces the following output:
            //
            // Finally block
            // Catch block