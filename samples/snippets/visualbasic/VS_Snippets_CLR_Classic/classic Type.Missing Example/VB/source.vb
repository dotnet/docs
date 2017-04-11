' <Snippet1>
Imports System
Imports System.Reflection

Public Class OptionalArg
    Public Sub MyMethod(ByVal a As Integer, _
        Optional ByVal b As Double = 1.2, _
        Optional ByVal c As Integer = 1)
        
        Console.WriteLine("a = " & a & " b = " & b & " c = " & c)
    End Sub
End Class

Class Example
    Public Shared Sub Main()
        Dim o As New OptionalArg()
        Dim t As Type
        t = GetType(OptionalArg)

        Dim bf As BindingFlags = _
            BindingFlags.Public Or BindingFlags.Instance Or _
            BindingFlags.InvokeMethod Or BindingFlags.OptionalParamBinding

        t.InvokeMember("MyMethod", bf, Nothing, o, New Object() {10, 55.3, 12})
        t.InvokeMember("MyMethod", bf, Nothing, o, New Object() {10, 1.3, Type.Missing})
        t.InvokeMember("MyMethod", bf, Nothing, o, New Object() {10, Type.Missing, Type.Missing})
    End Sub
End Class
' </Snippet1>