
Imports System
Imports System.Reflection

' <Snippet2>
Public Class Base(Of T, U)
End Class

Public Class Derived(Of V)
    Inherits Base(Of String, V)

    Public F As G(Of Derived(Of V))

    Public Class Nested
    End Class
End Class

Public Class G(Of T)
End Class
' </Snippet2>

Module Example

    Sub Main
    End Sub

End Module

