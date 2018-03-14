'<snippet1>
Imports System.ComponentModel

Public Class Class1

    Private ageval As Integer

    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
    Public Property Age() As Integer

        Get
            Return ageval
        End Get

        Set(ByVal Value As Integer)
            If Not ageval.Equals(Value) Then
                ageval = Value
            End If
        End Set

    End Property

End Class
'</snippet1>
