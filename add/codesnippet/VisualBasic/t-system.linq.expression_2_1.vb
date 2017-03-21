    Class Animal
        Public Species As String
        Public Age As Integer
    End Class

    Shared Sub CreateMemberInitExpression()
        Dim newAnimal As System.Linq.Expressions.NewExpression = _
            System.Linq.Expressions.Expression.[New](Type.GetType("ExpressionVB.MemberInitExample+Animal"))

        Dim speciesMember As System.Reflection.MemberInfo = _
            Type.GetType("ExpressionVB.MemberInitExample+Animal").GetMember("Species")(0)
        Dim ageMember As System.Reflection.MemberInfo = _
            Type.GetType("ExpressionVB.MemberInitExample+Animal").GetMember("Age")(0)

        ' Create a MemberBinding object for each member
        ' that you want to initialize.
        Dim speciesMemberBinding As System.Linq.Expressions.MemberBinding = _
            System.Linq.Expressions.Expression.Bind( _
                speciesMember, _
                System.Linq.Expressions.Expression.Constant("horse"))
        Dim ageMemberBinding As System.Linq.Expressions.MemberBinding = _
            System.Linq.Expressions.Expression.Bind( _
                ageMember, _
                System.Linq.Expressions.Expression.Constant(12))

        ' Create a MemberInitExpression that represents initializing
        ' two members of the 'Animal' class.
        Dim memberInitExpression As System.Linq.Expressions.MemberInitExpression = _
            System.Linq.Expressions.Expression.MemberInit( _
                newAnimal, _
                speciesMemberBinding, _
                ageMemberBinding)

        Console.WriteLine(memberInitExpression.ToString())

        ' This code produces the following output:
        '
        ' new Animal() {Species = "horse", Age = 12}
    End Sub