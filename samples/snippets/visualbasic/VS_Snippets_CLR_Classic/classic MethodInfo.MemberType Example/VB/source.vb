' <Snippet1>
Imports System
Imports System.Reflection

Class MyMethodInfo

    Public Shared Function Main() As Integer
        Console.WriteLine("Reflection.MethodInfo")

        ' Get the Type and MethodInfo.
        Dim MyType As Type = Type.GetType("System.Reflection.FieldInfo")
        Dim Mymethodinfo As MethodInfo = MyType.GetMethod("GetValue")
        Console.WriteLine(MyType.FullName + "." + Mymethodinfo.Name)

        ' Get and display the MemberType property.
        Dim Mymembertypes As MemberTypes = Mymethodinfo.MemberType

        If MemberTypes.Constructor = Mymembertypes Then
            Console.WriteLine("MemberType is of type All.")

        ElseIf MemberTypes.Custom = Mymembertypes Then
            Console.WriteLine("MemberType is of type Custom.")

        ElseIf MemberTypes.Event = Mymembertypes Then
            Console.WriteLine("MemberType is of type Event.")

        ElseIf MemberTypes.Field = Mymembertypes Then
            Console.WriteLine("MemberType is of type Field.")

        ElseIf MemberTypes.Method = Mymembertypes Then
            Console.WriteLine("MemberType is of type Method.")

        ElseIf MemberTypes.Property = Mymembertypes Then
            Console.WriteLine("MemberType is of type Property.")

        ElseIf MemberTypes.TypeInfo = Mymembertypes Then
            Console.WriteLine("MemberType is of type TypeInfo.")

        End If
        Return 0
    End Function
End Class
' </Snippet1>
