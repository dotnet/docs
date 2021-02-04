Imports System

Namespace ca1043

    Public Class Months
        '<Snippet1>
        Private month() As String = {"Jan", "Feb", "..."}

        Default ReadOnly Property Item(index As Integer) As String
            Get
                Return month(index)
            End Get
        End Property
        '</Snippet1>

    End Class

End Namespace
