    ' Add the following directive to your file:
    ' Imports System.Linq.Expressions  

    Class TestClass
        Public Property Sample As Integer
    End Class

    Sub TestPropertyOrField()

        Dim obj As New TestClass()
        obj.Sample = 40

        ' This expression represents accessing a property or field.
        ' For static properties or fields, the first parameter must be Nothing.
        Dim memberExpr As Expression = Expression.PropertyOrField(
              Expression.Constant(obj),
              "Sample"
          )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(memberExpr).Compile()())
    End Sub

    ' This code example produces the following output:
    '
    ' 40