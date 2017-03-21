    ' Add the following directive to your file:
    ' Imports System.Linq.Expressions  

    Class TestPropertyClass
        Public Property Sample As Integer
    End Class

    Sub TestProperty()

        Dim obj As New TestPropertyClass()
        obj.Sample = 40

        ' This expression represents accessing a property.
        ' For static properties, the first parameter must be Nothing.
        Dim propertyExpr As Expression = Expression.Property(
              Expression.Constant(obj),
              "sample"
          )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(propertyExpr).Compile()())
    End Sub

    ' This code example produces the following output:
    '
    ' 40