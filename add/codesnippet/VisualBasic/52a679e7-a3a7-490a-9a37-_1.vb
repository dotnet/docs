        ' Create an expression tree that represents creating a string
        ' array with rank 2 and bounds (3,2).
        Dim newArrayExpression As System.Linq.Expressions.NewArrayExpression = _
            System.Linq.Expressions.Expression.NewArrayBounds( _
                    Type.GetType("System.String"), _
                    System.Linq.Expressions.Expression.Constant(3), _
                    System.Linq.Expressions.Expression.Constant(2))

        ' Output the string representation of the Expression.
        Console.WriteLine(newArrayExpression.ToString())

        ' This code produces the following output:
        '
        ' new System.String[,](3, 2)