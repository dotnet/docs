    Class Animal
        Dim species As String
    End Class

    Shared Sub CreateFieldExpression()
        Dim horse As New Animal

        ' Create a MemberExpression that represents getting
        ' the value of the 'species' field of class 'Animal'.
        Dim memberExpression As System.Linq.Expressions.MemberExpression = _
            System.Linq.Expressions.Expression.Field( _
                System.Linq.Expressions.Expression.Constant(horse), _
                "species")

        Console.WriteLine(memberExpression.ToString())

        ' This code produces the following output:
        '
        ' value(ExpressionVB.FieldExample+Animal).species
    End Sub