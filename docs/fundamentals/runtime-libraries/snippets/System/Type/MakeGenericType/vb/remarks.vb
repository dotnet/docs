' <Snippet1>
Public Class Base(Of T, U)
End Class
Public Class Derived(Of V)
    Inherits Base(Of Integer, V)
End Class
' </Snippet1>

' <Snippet2>
Public Class Outermost(Of T)
    Public Class Inner(Of U)
        Public Class Innermost1(Of V)
        End Class
        Public Class Innermost2
        End Class
    End Class
End Class
' </Snippet2>

Public Class ProgStubClass
    Shared Sub Main()
	End Sub
End Class