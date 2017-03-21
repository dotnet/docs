            // Add the following directive to your file:
            // using System.Linq.Expressions;

            // The Parameter expression is used to create a variable.
            ParameterExpression variableExpr = Expression.Variable(typeof(int), "sampleVar");

            // The block expression enables you to execute several expressions sequentually.
            // In this bloc, the variable is first initialized with 1. 
            // Then the AddAssign method adds 2 to the variable and assigns the result to the variable.
            BlockExpression addAssignExpr = Expression.Block(
                new ParameterExpression[] { variableExpr },
                Expression.Assign(variableExpr, Expression.Constant(1)),
                Expression.AddAssign(
                    variableExpr,
                    Expression.Constant(2)
                )
            );

            // Print out the expression from the block expression.
            Console.WriteLine("The expressions from the block expression:");
            foreach (var expr in addAssignExpr.Expressions)
                Console.WriteLine(expr.ToString());

            Console.WriteLine("The result of executing the expression tree:");
            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(Expression.Lambda<Func<int>>(addAssignExpr).Compile()());

            // This code example produces the following output:
            //
            // The expressions from the block expression:
            // (sampleVar = 1)
            // (sampleVar += 2)

            // The result of executing the expression tree:
            // 3