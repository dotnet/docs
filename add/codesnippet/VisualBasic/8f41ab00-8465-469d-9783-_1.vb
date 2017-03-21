        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  
        Public Class SampleClass
            Public Function AddIntegers(ByVal arg1 As Integer, ByVal arg2 As Integer) As Integer
                Return (arg1 + arg2)
            End Function
        End Class
        Public Shared Sub TestCall()
            ' This expression represents a call to an instance method that has two arguments.
            ' The first argument is an expression that creates a new object of the specified type.
            Dim callExpr As Expression = Expression.Call(
                Expression.[New](GetType(SampleClass)),
                GetType(SampleClass).GetMethod("AddIntegers", New Type() {GetType(Integer), GetType(Integer)}),
                Expression.Constant(1),
                Expression.Constant(2)
              )

            ' Print the expression.
            Console.WriteLine(callExpr.ToString())

            ' The following statement first creates an expression tree,
            ' then compiles it, and then executes it.
            Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(callExpr).Compile()())
        End Sub

        ' This code example produces the following output:
        '
        ' new SampleClass().AddIntegers(1, 2)
        ' 3