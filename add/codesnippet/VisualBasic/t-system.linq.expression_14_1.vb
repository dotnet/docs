        Dim gradeArray(,) As String = _
            {{"chemistry", "history", "mathematics"}, {"78", "61", "82"}}

        Dim arrayExpression As System.Linq.Expressions.Expression = _
            System.Linq.Expressions.Expression.Constant(gradeArray)

        ' Create a MethodCallExpression that represents indexing
        ' into the two-dimensional array 'gradeArray' at (0, 2).
        ' Executing the expression would return "mathematics".
        Dim methodCallExpression As System.Linq.Expressions.MethodCallExpression = _
            System.Linq.Expressions.Expression.ArrayIndex( _
                arrayExpression, _
                System.Linq.Expressions.Expression.Constant(0), _
                System.Linq.Expressions.Expression.Constant(2))

        Console.WriteLine(methodCallExpression.ToString())

        ' This code produces the following output:
        '
        ' value(System.String[,]).Get(0, 2)