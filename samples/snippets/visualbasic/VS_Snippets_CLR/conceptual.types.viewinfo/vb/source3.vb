' <snippet3>
' This code displays information about the GetValue method of FieldInfo.
Imports System.Reflection
Class MyMethodInfo
    Public Shared Sub Main()
        Console.WriteLine("Reflection.MethodInfo")
        ' Gets and displays the Type.
        Dim myType As Type = Type.GetType("System.Reflection.FieldInfo")
        ' Specifies the member for which you want type information.
        Dim myMethodInfo As MethodInfo = myType.GetMethod("GetValue")
        Console.WriteLine((myType.FullName & "." & myMethodInfo.Name))
        ' Gets and displays the MemberType property.
        Dim myMemberTypes As MemberTypes = myMethodInfo.MemberType
        If MemberTypes.Constructor = myMemberTypes Then
            Console.WriteLine("MemberType is of type All")
        ElseIf MemberTypes.Custom = myMemberTypes Then
            Console.WriteLine("MemberType is of type Custom")
        ElseIf MemberTypes.Event = myMemberTypes Then
            Console.WriteLine("MemberType is of type Event")
        ElseIf MemberTypes.Field = myMemberTypes Then
            Console.WriteLine("MemberType is of type Field")
        ElseIf MemberTypes.Method = myMemberTypes Then
            Console.WriteLine("MemberType is of type Method")
        ElseIf MemberTypes.Property = myMemberTypes Then
            Console.WriteLine("MemberType is of type Property")
        ElseIf MemberTypes.TypeInfo = myMemberTypes Then
            Console.WriteLine("MemberType is of type TypeInfo")
        End If
        Return
    End Sub
End Class
' </snippet3>
