            // Create a BinaryExpression that represents subtracting 14 from 53.
            System.Linq.Expressions.BinaryExpression binaryExpression =
                System.Linq.Expressions.Expression.MakeBinary(
                    System.Linq.Expressions.ExpressionType.Subtract,
                    System.Linq.Expressions.Expression.Constant(53),
                    System.Linq.Expressions.Expression.Constant(14));

            Console.WriteLine(binaryExpression.ToString());

            // This code produces the following output:
            //
            // (53 - 14)