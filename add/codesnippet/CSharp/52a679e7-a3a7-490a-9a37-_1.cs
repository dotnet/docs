            // Create an expression tree that represents creating a 
            // two-dimensional array of type string with bounds [3,2].
            System.Linq.Expressions.NewArrayExpression newArrayExpression =
                System.Linq.Expressions.Expression.NewArrayBounds(
                        typeof(string),
                        System.Linq.Expressions.Expression.Constant(3),
                        System.Linq.Expressions.Expression.Constant(2));

            // Output the string representation of the Expression.
            Console.WriteLine(newArrayExpression.ToString());

            // This code produces the following output:
            //
            // new System.String[,](3, 2)