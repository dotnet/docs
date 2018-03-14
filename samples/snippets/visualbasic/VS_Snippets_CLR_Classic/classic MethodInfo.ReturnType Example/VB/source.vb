' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Class Mymethodinfo1

    Public Shared Function Main() As Integer
        Console.WriteLine(ControlChars.Cr + "Reflection.MethodInfo")

        'Get the Type and MethodInfo.
        Dim MyType As Type = Type.GetType("System.Reflection.FieldInfo")
        Dim Mymethodinfo As MethodInfo = MyType.GetMethod("GetValue")
        Console.Write(ControlChars.Cr _
           + MyType.FullName + "." + Mymethodinfo.Name)

        'Get and display the ReturnType.
        Console.Write(ControlChars.Cr _
           + "ReturnType = {0}", Mymethodinfo.ReturnType)
        Return 0
    End Function
End Class
' </Snippet1>