Public Class B(Of T, U)
End Class
Public Class A(Of V)
    Public Function GetSomething(Of X)() As B(Of V, X)
        Return New B(Of V, X)()
    End Function
End Class