' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Public Class MainClass
    Public Overloads Shared Sub Main(ByVal args() As String)
        Dim tDate As Type = GetType(System.DateTime)
        Dim result As [Object] = tDate.InvokeMember("Now", _
            BindingFlags.GetProperty, Nothing, Nothing, New [Object](-1) {})
        Console.WriteLine(result.ToString())
    End Sub 'Main
End Class 'MainClass
' </Snippet1>