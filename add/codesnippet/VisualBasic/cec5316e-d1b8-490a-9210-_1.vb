        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  
        Public Class SampleClass
            Shared Function Increment(ByVal arg1 As Integer) As Integer
                Return arg1 + 1
            End Function
        End Class
        Shared Sub TestCall()
            'This expression represents a call to an instance method with one argument.
            Dim callExpr As Expression = Expression.Call(
                GetType(SampleClass).GetMethod("Increment"),
                Expression.Constant(2))

            ' Print the expression.
            Console.WriteLine(callExpr.ToString())

            ' The following statement first creates an expression tree,
            ' then compiles it, and then executes it.
            Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(callExpr).Compile()())
        End Sub

        ' This code example produces the following output:
        '
        ' Increment(2)
        ' 3
