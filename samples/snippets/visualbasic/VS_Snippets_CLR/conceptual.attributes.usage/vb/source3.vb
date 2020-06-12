'<snippet18>
Imports System.Reflection
Imports CustomCodeAttributes

<Developer("Joan Smith", "42", Reviewed:=True)>
Class MainApp
    Public Shared Sub Main()
        ' Call function to get and display the attribute.
        GetAttribute(GetType(MainApp))
    End Sub

    Public Shared Sub GetAttribute(t As Type)
        ' Get instance of the attribute.
        Dim MyAttribute As DeveloperAttribute =
            CType(Attribute.GetCustomAttribute(t, GetType(DeveloperAttribute)), DeveloperAttribute)

        If MyAttribute Is Nothing Then
            Console.WriteLine("The attribute was not found.")
        Else
            ' Get the Name value.
            Console.WriteLine("The Name Attribute is: {0}.", MyAttribute.Name)
            ' Get the Level value.
            Console.WriteLine("The Level Attribute is: {0}.", MyAttribute.Level)
            ' Get the Reviewed value.
            Console.WriteLine("The Reviewed Attribute is: {0}.", MyAttribute.Reviewed)
        End If
    End Sub
End Class
'</snippet18>

Class GetAttribTest1
    '<snippet19>
    Public Shared Sub GetAttribute(t As Type)
        Dim MyAttributes() As DeveloperAttribute =
            CType(Attribute.GetCustomAttributes(t, GetType(DeveloperAttribute)), DeveloperAttribute())

        If MyAttributes.Length = 0 Then
            Console.WriteLine("The attribute was not found.")
        Else
            For i As Integer = 0 To MyAttributes.Length - 1
                ' Get the Name value.
                Console.WriteLine("The Name Attribute is: {0}.", MyAttributes(i).Name)
                ' Get the Level value.
                Console.WriteLine("The Level Attribute is: {0}.", MyAttributes(i).Level)
                ' Get the Reviewed value.
                Console.WriteLine("The Reviewed Attribute is: {0}.", MyAttributes(i).Reviewed)
            Next i
        End If
    End Sub
    '</snippet19>
End Class

Class GetAttribTest2
    '<snippet20>
    Public Shared Sub GetAttribute(t As Type)
        Dim att As DeveloperAttribute

        ' Get the class-level attributes.

        ' Put the instance of the attribute on the class level in the att object.
        att = CType(Attribute.GetCustomAttribute(t, GetType(DeveloperAttribute)), DeveloperAttribute)

        If att Is Nothing
            Console.WriteLine("No attribute in class {0}.\n", t.ToString())
        Else
            Console.WriteLine("The Name Attribute on the class level is: {0}.", att.Name)
            Console.WriteLine("The Level Attribute on the class level is: {0}.", att.Level)
            Console.WriteLine("The Reviewed Attribute on the class level is: {0}.\n", att.Reviewed)
        End If

        ' Get the method-level attributes.

        ' Get all methods in this class, and put them
        ' in an array of System.Reflection.MemberInfo objects.
        Dim MyMemberInfo() As MemberInfo = t.GetMethods()

        ' Loop through all methods in this class that are in the
        ' MyMemberInfo array.
        For i As Integer = 0 To MyMemberInfo.Length - 1
            att = CType(Attribute.GetCustomAttribute(MyMemberInfo(i), _
                GetType(DeveloperAttribute)), DeveloperAttribute)
            If att Is Nothing Then
                Console.WriteLine("No attribute in member function {0}.\n", MyMemberInfo(i).ToString())
            Else
                Console.WriteLine("The Name Attribute for the {0} member is: {1}.",
                    MyMemberInfo(i).ToString(), att.Name)
                Console.WriteLine("The Level Attribute for the {0} member is: {1}.",
                    MyMemberInfo(i).ToString(), att.Level)
                Console.WriteLine("The Reviewed Attribute for the {0} member is: {1}.\n",
                    MyMemberInfo(i).ToString(), att.Reviewed)
            End If
        Next
    End Sub
    '</snippet20>
End Class
