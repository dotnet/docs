Module ExecutingExprTrees
    Sub Main()
        'ArrayIndex()
        'NewArrayBounds()
        'MemberInit()
        'NewExample()
        TypeAs()
        'TypeIs()
    End Sub

    Sub NewArrayInit()
        ' <Snippet1>
        Dim trees As New System.Collections.Generic.List(Of System.Linq.Expressions.Expression) _
                (New System.Linq.Expressions.Expression() _
                 {System.Linq.Expressions.Expression.Constant("oak"), _
                  System.Linq.Expressions.Expression.Constant("fir"), _
                  System.Linq.Expressions.Expression.Constant("spruce"), _
                  System.Linq.Expressions.Expression.Constant("alder")})

        ' Create an expression tree that represents creating and  
        ' initializing a one-dimensional array of type string.
        Dim newArrayExpression As System.Linq.Expressions.NewArrayExpression = _
            System.Linq.Expressions.Expression.NewArrayInit(Type.GetType("System.String"), trees)

        ' Output the string representation of the Expression.
        Console.WriteLine(newArrayExpression.ToString())

        ' This code produces the following output:
        '
        ' new [] {"oak", "fir", "spruce", "alder"}
        ' </Snippet1>
    End Sub

    Sub NewArrayBounds()
        ' <Snippet2>
        ' Create an expression tree that represents creating a string
        ' array with rank 2 and bounds (3,2).
        Dim newArrayExpression As System.Linq.Expressions.NewArrayExpression = _
            System.Linq.Expressions.Expression.NewArrayBounds( _
                    Type.GetType("System.String"), _
                    System.Linq.Expressions.Expression.Constant(3), _
                    System.Linq.Expressions.Expression.Constant(2))

        ' Output the string representation of the Expression.
        Console.WriteLine(newArrayExpression.ToString())

        ' This code produces the following output:
        '
        ' new System.String[,](3, 2)
        ' </Snippet2>
    End Sub

    Sub ArrayIndex()
        ' <Snippet3>
        Dim gradeArray(,) As String = _
            {{"chemistry", "history", "mathematics"}, {"78", "61", "82"}}

        Dim arrayExpression As System.Linq.Expressions.Expression = _
            System.Linq.Expressions.Expression.Constant(gradeArray)

        ' Create a MethodCallExpression that represents indexing
        ' into the two-dimensional array 'gradeArray' at (0, 2).
        ' Executing the expression would return "mathematics".
        Dim methodCallExpression As System.Linq.Expressions.MethodCallExpression = _
            System.Linq.Expressions.Expression.ArrayIndex( _
                arrayExpression, _
                System.Linq.Expressions.Expression.Constant(0), _
                System.Linq.Expressions.Expression.Constant(2))

        Console.WriteLine(methodCallExpression.ToString())

        ' This code produces the following output:
        '
        ' value(System.String[,]).Get(0, 2)
        ' </Snippet3>
    End Sub

    Sub ElementInit()
        ' <Snippet4>
        Dim tree As String = "maple"

        Dim addMethod As System.Reflection.MethodInfo = _
            Type.GetType("System.Collections.Generic.Dictionary`2[System.Int32, System.String]").GetMethod("Add")

        ' Create an ElementInit that represents calling
        ' Dictionary(Of Integer, String).Add(tree.Length, tree).
        Dim elementInit As System.Linq.Expressions.ElementInit = _
            System.Linq.Expressions.Expression.ElementInit( _
                addMethod, _
                System.Linq.Expressions.Expression.Constant(tree.Length), _
                System.Linq.Expressions.Expression.Constant(tree))

        Console.WriteLine(elementInit.ToString())

        ' This code produces the following output:
        '
        ' Void Add(Int32, System.String)(5,"maple")
        ' </Snippet4>
    End Sub

    Sub Field()
        FieldExample.CreateFieldExpression()
    End Sub

    Sub Invoke()
        ' <Snippet6>
        Dim largeSumTest As System.Linq.Expressions.Expression(Of System.Func(Of Integer, Integer, Boolean)) = _
            Function(num1, num2) (num1 + num2) > 1000

        ' Create an InvocationExpression that represents applying
        ' the arguments '539' and '281' to the lambda expression 'largeSumTest'.
        Dim invocationExpression As System.Linq.Expressions.InvocationExpression = _
            System.Linq.Expressions.Expression.Invoke( _
                largeSumTest, _
                System.Linq.Expressions.Expression.Constant(539), _
                System.Linq.Expressions.Expression.Constant(281))

        Console.WriteLine(invocationExpression.ToString())

        ' This code produces the following output:
        '
        ' Invoke((num1, num2) => ((num1 + num2) > 1000),539,281)
        ' </Snippet6>
    End Sub

    Sub ListInit()
        ' <Snippet7>
        Dim tree1 As String = "maple"
        Dim tree2 As String = "oak"

        Dim addMethod As System.Reflection.MethodInfo = _
            Type.GetType("System.Collections.Generic.Dictionary`2[System.Int32, System.String]").GetMethod("Add")

        ' Create two ElementInit objects that represent the
        ' two key-value pairs to add to the Dictionary.
        Dim elementInit1 As System.Linq.Expressions.ElementInit = _
            System.Linq.Expressions.Expression.ElementInit( _
                addMethod, _
                System.Linq.Expressions.Expression.Constant(tree1.Length), _
                System.Linq.Expressions.Expression.Constant(tree1))
        Dim elementInit2 As System.Linq.Expressions.ElementInit = _
            System.Linq.Expressions.Expression.ElementInit( _
                addMethod, _
                System.Linq.Expressions.Expression.Constant(tree2.Length), _
                System.Linq.Expressions.Expression.Constant(tree2))

        ' Create a NewExpression that represents constructing
        ' a new instance of Dictionary(Of Integer, String).
        Dim newDictionaryExpression As System.Linq.Expressions.NewExpression = _
            System.Linq.Expressions.Expression.[New](Type.GetType("System.Collections.Generic.Dictionary`2[System.Int32, System.String]"))

        ' Create a ListInitExpression that represents initializing
        ' a new Dictionary(Of T) instance with two key-value pairs.
        Dim listInitExpression As System.Linq.Expressions.ListInitExpression = _
            System.Linq.Expressions.Expression.ListInit( _
                newDictionaryExpression, _
                elementInit1, _
                elementInit2)

        Console.WriteLine(listInitExpression.ToString())

        ' This code produces the following output:
        '
        ' new Dictionary`2() {Void Add(Int32, System.String)(5,"maple"),
        ' Void Add(Int32, System.String)(3,"oak")
        ' </Snippet7>
    End Sub

    Sub MakeBinary()
        ' <Snippet8>
        ' Create a BinaryExpression that represents subtracting 14 from 53.
        Dim binaryExpression As System.Linq.Expressions.BinaryExpression = _
            System.Linq.Expressions.Expression.MakeBinary( _
                System.Linq.Expressions.ExpressionType.Subtract, _
                System.Linq.Expressions.Expression.Constant(53), _
                System.Linq.Expressions.Expression.Constant(14))

        Console.WriteLine(binaryExpression.ToString())

        ' This code produces the following output:
        '
        ' (53 - 14)
        ' </Snippet8>
    End Sub

    Sub MemberInit()
        MemberInitExample.CreateMemberInitExpression()
    End Sub

    Sub NewExample()
        ' <Snippet10>
        ' Create a NewExpression that represents constructing
        ' a new instance of Dictionary(Of Integer, String).
        Dim newDictionaryExpression As System.Linq.Expressions.NewExpression = _
            System.Linq.Expressions.Expression.[New]( _
                Type.GetType("System.Collections.Generic.Dictionary`2[System.Int32, System.String]"))

        Console.WriteLine(newDictionaryExpression.ToString())

        ' This code produces the following output:
        '
        ' new Dictionary`2()
        ' </Snippet10>
    End Sub

    Sub TypeAs()
        ' <Snippet11>
        ' Create a UnaryExpression that represents a reference
        ' conversion of an Integer to an Integer? (a nullable Integer).
        Dim typeAsExpression As System.Linq.Expressions.UnaryExpression = _
            System.Linq.Expressions.Expression.TypeAs( _
                System.Linq.Expressions.Expression.Constant(34, Type.GetType("System.Int32")), _
                Type.GetType("System.Nullable`1[System.Int32]"))

        Console.WriteLine(typeAsExpression.ToString())

        ' This code produces the following output:
        '
        ' (34 As Nullable`1)
        ' </Snippet11>
    End Sub

    Sub TypeIs()
        ' <Snippet12>
        ' Create a TypeBinaryExpression that represents a
        ' type test of the String "spruce" against the Int32 type.
        Dim typeBinaryExpression As System.Linq.Expressions.TypeBinaryExpression = _
            System.Linq.Expressions.Expression.TypeIs( _
                System.Linq.Expressions.Expression.Constant("spruce"), _
                Type.GetType("System.Int32"))

        Console.WriteLine(typeBinaryExpression.ToString())

        ' This code produces the following output:
        '
        ' ("spruce" Is Int32)
        ' </Snippet12>
    End Sub
End Module

Class FieldExample
    ' <Snippet5>
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
    ' </Snippet5>
End Class

Class MemberInitExample
    ' <Snippet9>
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
    ' </Snippet9>
End Class

