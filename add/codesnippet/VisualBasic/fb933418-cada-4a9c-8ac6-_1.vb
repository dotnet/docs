        ' Create a UnaryExpression that represents a reference
        ' conversion of an Integer to an Integer? (a nullable Integer).
        Dim typeAsExpression As System.Linq.Expressions.UnaryExpression = _
            System.Linq.Expressions.Expression.TypeAs( _
                System.Linq.Expressions.Expression.Constant(34, Type.GetType("System.Int32")), _
                Type.GetType("System.Nullable`1[System.Int32]"))

        Console.WriteLine(typeAsExpression.ToString())

        ' This code produces the following output:
        '
        ' (34 As Nullable`1)