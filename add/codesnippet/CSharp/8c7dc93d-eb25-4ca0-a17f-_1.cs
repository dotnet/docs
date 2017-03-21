            // Create a TypeBinaryExpression that represents a
            // type test of the string "spruce" against the 'int' type.
            System.Linq.Expressions.TypeBinaryExpression typeBinaryExpression =
                System.Linq.Expressions.Expression.TypeIs(
                    System.Linq.Expressions.Expression.Constant("spruce"),
                    typeof(int));

            Console.WriteLine(typeBinaryExpression.ToString());

            // This code produces the following output:
            //
            // ("spruce" Is Int32)