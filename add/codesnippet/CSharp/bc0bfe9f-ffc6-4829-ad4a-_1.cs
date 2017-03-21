            // Add the following directive to your file:
            // using System.Linq.Expressions;  


            // This block has a parameter expression
            // that represents a variable within the block scope.
            // It assigns a value to the variable,
            // and then adds a constant to the assigned value. 

            ParameterExpression varExpr = Expression.Variable(typeof(int), "sampleVar");
            BlockExpression blockExpr = Expression.Block(
                new ParameterExpression[] { varExpr },
                Expression.Assign(varExpr, Expression.Constant(1)),
                Expression.Add(varExpr, Expression.Constant(5))
            );

            // Print out the expressions from the block expression.
            Console.WriteLine("The expressions from the block expression:");
            foreach (var expr in blockExpr.Expressions)
                Console.WriteLine(expr.ToString());

            Console.WriteLine("The result of executing the expression tree:");
            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(
                Expression.Lambda<Func<int>>(blockExpr).Compile()());

            // This code example produces the following output:
            // The expressions from the block expression:
            // (sampleVar = 1)
            // (sampleVar + 5)
            // The result of executing the expression tree:
            // 6
