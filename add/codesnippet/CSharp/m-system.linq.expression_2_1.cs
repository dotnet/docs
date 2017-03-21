            // Add the following directive to the file:
            // using System.Linq.Expressions;  

            // Creating a parameter expression.
            ParameterExpression value = Expression.Parameter(typeof(int), "value");

            // Creating an expression to hold a local variable. 
            ParameterExpression result = Expression.Parameter(typeof(int), "result");

            // Creating a label to jump to from a loop.
            LabelTarget label = Expression.Label(typeof(int));

            // Creating a method body.
            BlockExpression block = Expression.Block(
                new[] { result },
                Expression.Assign(result, Expression.Constant(1)),
                    Expression.Loop(
                       Expression.IfThenElse(
                           Expression.GreaterThan(value, Expression.Constant(1)),
                           Expression.MultiplyAssign(result,
                               Expression.PostDecrementAssign(value)),
                           Expression.Break(label, result)
                       ),
                   label
                )
            );

            // Compile and run an expression tree.
            int factorial = Expression.Lambda<Func<int, int>>(block, value).Compile()(5);

            Console.WriteLine(factorial);

            // This code example produces the following output:
            //
            // 120