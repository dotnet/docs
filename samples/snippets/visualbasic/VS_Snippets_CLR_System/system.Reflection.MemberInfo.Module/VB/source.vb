'<Snippet1>
Imports System
Imports System.Reflection

Public Class Test
    Public Overrides Function ToString() As String
        Return "An instance of class Test!"
    End Function
End Class

Public Class Example
    Public Shared Sub Main()
        Dim t As New Test()
        Dim mi As MethodInfo = t.GetType().GetMethod("ToString")
        Console.WriteLine(mi.Name & " is defined in " & mi.Module.Name)

        mi = t.GetType().GetMethod("GetHashCode")
        Console.WriteLine(mi.Name & " is defined in " & mi.Module.Name)
    End Sub
End Class

' This example produces code similar to the following:
'
'ToString is defined in source.exe
'GetHashCode is defined in mscorlib.dll
'</Snippet1>