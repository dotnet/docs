    Private _current As String

    Public ReadOnly Property Current() As String _
        Implements IEnumerator(Of String).Current

        Get
            If _sr Is Nothing OrElse _current Is Nothing Then
                Throw New InvalidOperationException()
            End If

            Return _current
        End Get
    End Property

    Private ReadOnly Property Current1() As Object _
        Implements IEnumerator.Current

        Get
            Return Me.Current
        End Get
    End Property