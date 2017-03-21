        ' Create a BinaryExpression that represents subtracting 14 from 53.
        Dim binaryExpression As System.Linq.Expressions.BinaryExpression = _
            System.Linq.Expressions.Expression.MakeBinary( _
                System.Linq.Expressions.ExpressionType.Subtract, _
                System.Linq.Expressions.Expression.Constant(53), _
                System.Linq.Expressions.Expression.Constant(14))

        Console.WriteLine(binaryExpression.ToString())

        ' This code produces the following output:
        '
        ' (53 - 14)