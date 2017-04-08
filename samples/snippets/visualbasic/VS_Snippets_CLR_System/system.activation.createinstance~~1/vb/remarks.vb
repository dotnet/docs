Imports System

Public Class Dummy
' <Snippet1>
    Public Shared Function Factory(Of T As New)() As T
        Return New T()
    End Function
' </Snippet1>
End Class

Public Class ProgStubClass
    Shared Sub Main()
	End Sub
End Class