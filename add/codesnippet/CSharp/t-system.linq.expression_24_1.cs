            System.Linq.Expressions.Expression<Func<int, int, bool>> largeSumTest =
                (num1, num2) => (num1 + num2) > 1000;

            // Create an InvocationExpression that represents applying
            // the arguments '539' and '281' to the lambda expression 'largeSumTest'.
            System.Linq.Expressions.InvocationExpression invocationExpression =
                System.Linq.Expressions.Expression.Invoke(
                    largeSumTest,
                    System.Linq.Expressions.Expression.Constant(539),
                    System.Linq.Expressions.Expression.Constant(281));

            Console.WriteLine(invocationExpression.ToString());

            // This code produces the following output:
            //
            // Invoke((num1, num2) => ((num1 + num2) > 1000),539,281)