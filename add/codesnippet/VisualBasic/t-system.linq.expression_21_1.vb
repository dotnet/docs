        ' Create a TypeBinaryExpression that represents a
        ' type test of the String "spruce" against the Int32 type.
        Dim typeBinaryExpression As System.Linq.Expressions.TypeBinaryExpression = _
            System.Linq.Expressions.Expression.TypeIs( _
                System.Linq.Expressions.Expression.Constant("spruce"), _
                Type.GetType("System.Int32"))

        Console.WriteLine(typeBinaryExpression.ToString())

        ' This code produces the following output:
        '
        ' ("spruce" Is Int32)