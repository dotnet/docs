    ' Add the following directive to your file:
    ' Imports System.Linq.Expressions

    Class TestFieldClass
        Dim sample As Integer = 40
    End Class

    Sub TestField()

        Dim obj As New TestFieldClass()

        ' This expression represents accessing a field.
        ' For static fields, the first parameter must be Nothing.
        Dim fieldExpr As Expression = Expression.Field(
              Expression.Constant(obj),
              "sample"
          )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(fieldExpr).Compile()())
    End Sub

    ' This code example produces the following output:
    '
    ' 40