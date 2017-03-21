        Dim trees As New System.Collections.Generic.List(Of System.Linq.Expressions.Expression) _
                (New System.Linq.Expressions.Expression() _
                 {System.Linq.Expressions.Expression.Constant("oak"), _
                  System.Linq.Expressions.Expression.Constant("fir"), _
                  System.Linq.Expressions.Expression.Constant("spruce"), _
                  System.Linq.Expressions.Expression.Constant("alder")})

        ' Create an expression tree that represents creating and  
        ' initializing a one-dimensional array of type string.
        Dim newArrayExpression As System.Linq.Expressions.NewArrayExpression = _
            System.Linq.Expressions.Expression.NewArrayInit(Type.GetType("System.String"), trees)

        ' Output the string representation of the Expression.
        Console.WriteLine(newArrayExpression.ToString())

        ' This code produces the following output:
        '
        ' new [] {"oak", "fir", "spruce", "alder"}