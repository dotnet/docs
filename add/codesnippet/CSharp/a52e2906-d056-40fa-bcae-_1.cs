            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // To demonstrate the assignment operation, we create a variable.
            ParameterExpression variableExpr = Expression.Variable(typeof(String), "sampleVar");

            // This expression represents the assignment of a value
            // to a variable expression.
            // It copies a value for value types, and
            // copies a reference for reference types.
            Expression assignExpr = Expression.Assign(
                variableExpr,
                Expression.Constant("Hello World!")
                );

            // The block expression allows for executing several expressions sequentually.
            // In this block, we pass the variable expression as a parameter,
            // and then assign this parameter a value in the assign expression.
            Expression blockExpr = Expression.Block(
                new ParameterExpression[] { variableExpr },
                assignExpr
                );

            // Print out the assign expression.
            Console.WriteLine(assignExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.  
            Console.WriteLine(Expression.Lambda<Func<String>>(blockExpr).Compile()());

            // This code example produces the following output:
            //
            // (sampleVar = "Hello World!")
            // Hello World!
