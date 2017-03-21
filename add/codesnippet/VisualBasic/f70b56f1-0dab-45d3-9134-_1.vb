    ' Add the following directive to your file:
    ' Imports System.Linq.Expressions  

    Class TestMemberInitClass
        Public Property Sample As Integer
    End Class

    Sub MemberInit()
        ' This expression creates a new TestMemberInitClass object
        ' and assigns 10 to its Sample property.
        Dim testExpr As Expression = Expression.MemberInit(
            Expression.[New](GetType(TestMemberInitClass)),
            New List(Of MemberBinding)() From {
                Expression.Bind(GetType(TestMemberInitClass).GetMember("Sample")(0), Expression.Constant(10))
            }
        )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Dim test = Expression.Lambda(Of Func(Of TestMemberInitClass))(testExpr).Compile()()
        Console.WriteLine(test.Sample)
    End Sub

    ' This code example produces the following output:
    '
    ' 10