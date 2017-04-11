' <Snippet2>
Public Class AndAlsoModifier
    Inherits ExpressionVisitor

    Public Function Modify(ByVal expr As Expression) As Expression
        Return Visit(expr)
    End Function

    Protected Overrides Function VisitBinary(ByVal b As BinaryExpression) As Expression
        If b.NodeType = ExpressionType.AndAlso Then
            Dim left = Me.Visit(b.Left)
            Dim right = Me.Visit(b.Right)

            ' Make this binary expression an OrElse operation instead 
            ' of an AndAlso operation.
            Return Expression.MakeBinary(ExpressionType.OrElse, left, right, _
                                         b.IsLiftedToNull, b.Method)
        End If

        Return MyBase.VisitBinary(b)
    End Function
End Class
' </Snippet2>