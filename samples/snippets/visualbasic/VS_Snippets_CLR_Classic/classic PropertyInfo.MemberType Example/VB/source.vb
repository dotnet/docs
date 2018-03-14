' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Class Mypropertyinfo

    Public Shared Function Main() As Integer
        Console.WriteLine(ControlChars.CrLf & "Reflection.PropertyInfo")

        ' Get the type and PropertyInfo.
        Dim MyType As Type = Type.GetType("System.Reflection.MemberInfo")
        Dim Mypropertyinfo As PropertyInfo = MyType.GetProperty("Name")

        ' Read and display the MemberType property.
        Console.WriteLine("MemberType = " & _
           Mypropertyinfo.MemberType.ToString())

        Return 0
    End Function
End Class
' </Snippet1>