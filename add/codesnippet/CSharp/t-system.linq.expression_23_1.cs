            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // A parameter for the lambda expression.
            ParameterExpression paramExpr = Expression.Parameter(typeof(int), "arg");

            // This expression represents a lambda expression
            // that adds 1 to the parameter value.
            LambdaExpression lambdaExpr = Expression.Lambda(
                Expression.Add(
                    paramExpr,
                    Expression.Constant(1)
                ),
                new List<ParameterExpression>() { paramExpr }
            );
            
            // Print out the expression.
            Console.WriteLine(lambdaExpr);

            // Compile and run the lamda expression.
            // The value of the parameter is 1.
            Console.WriteLine(lambdaExpr.Compile().DynamicInvoke(1));

            // This code example produces the following output:
            //
            // arg => (arg +1)
            // 2