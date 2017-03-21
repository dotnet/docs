            // Create a UnaryExpression that represents a
            // conversion of an int to an int?.
            System.Linq.Expressions.UnaryExpression typeAsExpression =
                System.Linq.Expressions.Expression.TypeAs(
                    System.Linq.Expressions.Expression.Constant(34, typeof(int)),
                    typeof(int?));

            Console.WriteLine(typeAsExpression.ToString());

            // This code produces the following output:
            //
            // (34 As Nullable`1)