' <Snippet1>
Imports System.Reflection

Public Class MainClass
    Public Overloads Shared Sub Main(ByVal args() As String)
        Dim tDate As Type = GetType(System.DateTime)
        Dim result As [Object] = tDate.InvokeMember("Now", _
            BindingFlags.GetProperty, Nothing, Nothing, New [Object](-1) {})
        Console.WriteLine(result.ToString())
    End Sub
End Class
' </Snippet1>
