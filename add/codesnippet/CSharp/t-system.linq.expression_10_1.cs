            // Add the following directive to the file:
            // using System.Linq.Expressions;  

            // Creating a parameter for the expression tree.
            ParameterExpression param = Expression.Parameter(typeof(int));

            // Creating an expression for the method call and specifying its parameter.
            MethodCallExpression methodCall = Expression.Call(
                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(int) }),
                param
            );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Expression.Lambda<Action<int>>(
                methodCall,
                new ParameterExpression[] { param }
            ).Compile()(10);

            // This code example produces the following output:
            //
            // 10