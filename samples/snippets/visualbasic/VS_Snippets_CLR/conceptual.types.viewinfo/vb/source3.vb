' <snippet3>
' This code displays information about the GetValue method of FieldInfo.
Imports System
Imports System.Reflection
Class MyMethodInfo
    Public Shared Sub Main()
        Console.WriteLine("Reflection.MethodInfo")
        ' Gets and displays the Type.
        Dim MyType As Type = Type.GetType("System.Reflection.FieldInfo")
        ' Specifies the member for which you want type information.
        Dim Mymethodinfo As MethodInfo = MyType.GetMethod("GetValue")
        Console.WriteLine((MyType.FullName & "." & Mymethodinfo.Name))
        ' Gets and displays the MemberType property.
        Dim Mymembertypes As MemberTypes = Mymethodinfo.MemberType
        If MemberTypes.Constructor = Mymembertypes Then
            Console.WriteLine("MemberType is of type All")
        ElseIf MemberTypes.Custom = Mymembertypes Then
            Console.WriteLine("MemberType is of type Custom")
        ElseIf MemberTypes.Event = Mymembertypes Then
            Console.WriteLine("MemberType is of type Event")
        ElseIf MemberTypes.Field = Mymembertypes Then
            Console.WriteLine("MemberType is of type Field")
        ElseIf MemberTypes.Method = Mymembertypes Then
            Console.WriteLine("MemberType is of type Method")
        ElseIf MemberTypes.Property = Mymembertypes Then
            Console.WriteLine("MemberType is of type Property")
        ElseIf MemberTypes.TypeInfo = Mymembertypes Then
            Console.WriteLine("MemberType is of type TypeInfo")
        End If
        Return
    End Sub
End Class
' </snippet3>
