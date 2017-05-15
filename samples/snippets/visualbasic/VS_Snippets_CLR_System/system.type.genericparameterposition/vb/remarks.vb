Imports System

' <Snippet1>
Public Class B(Of T, U)
End Class
Public Class A(Of V)
    Public Function GetSomething(Of X)() As B(Of V, X)
        Return New B(Of V, X)()
    End Function
End Class
' </Snippet1>

Public Class ProgStubClass
    Shared Sub Main()
	End Sub
End Class