'<snippet1>
Imports System
'<snippet2>
Imports System.Reflection
<Assembly:AssemblyTitle("My Assembly")>
'</snippet2>

'<snippet3>
Public Class Example
    ' Specify attributes between square brackets in C#.
    ' This attribute is applied only to the Add method.
    <Obsolete("Will be removed in next version.")>
    Public Shared Function Add(a As Integer, b As Integer) As Integer
        Return a + b
    End Function
End Class

Class Test
    Public Shared Sub Main()
        ' This generates a compile-time warning.
        Dim i As Integer = Example.Add(2, 2)
    End Sub
End Class
'</snippet3>
'</snippet1>
