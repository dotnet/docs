'<Snippet1>
Imports System

Namespace DesignLibrary

    Public Class Months

        Private month() As String = {"Jan", "Feb", "..."}

        Default ReadOnly Property Item(index As Integer) As String
            Get
                Return month(index)
            End Get
        End Property

    End Class

End Namespace
'</Snippet1>
