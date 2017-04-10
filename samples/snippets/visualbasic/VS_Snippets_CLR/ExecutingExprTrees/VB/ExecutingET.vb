Imports System.Linq.Expressions

Module ExecutingExprTrees
    Sub Main()

        ' <Snippet1>
        ' The expression tree to execute.
        Dim be As BinaryExpression = Expression.Power(Expression.Constant(2.0R), Expression.Constant(3.0R))

        ' Create a lambda expression.
        Dim le As Expression(Of Func(Of Double)) = Expression.Lambda(Of Func(Of Double))(be)

        ' Compile the lambda expression.
        Dim compiledExpression As Func(Of Double) = le.Compile()

        ' Execute the lambda expression.
        Dim result As Double = compiledExpression()

        ' Display the result.
        MsgBox(result)

        ' This code produces the following output:
        ' 8

        ' </Snippet1>
    End Sub
End Module
