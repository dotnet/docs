            string[,] gradeArray =
                { {"chemistry", "history", "mathematics"}, {"78", "61", "82"} };

            System.Linq.Expressions.Expression arrayExpression =
                System.Linq.Expressions.Expression.Constant(gradeArray);

            // Create a MethodCallExpression that represents indexing
            // into the two-dimensional array 'gradeArray' at (0, 2).
            // Executing the expression would return "mathematics".
            System.Linq.Expressions.MethodCallExpression methodCallExpression =
                System.Linq.Expressions.Expression.ArrayIndex(
                    arrayExpression,
                    System.Linq.Expressions.Expression.Constant(0),
                    System.Linq.Expressions.Expression.Constant(2));

            Console.WriteLine(methodCallExpression.ToString());

            // This code produces the following output:
            //
            // value(System.String[,]).Get(0, 2)