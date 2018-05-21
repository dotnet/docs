    Public Class EventSource
        ' Declare an event.
        Public Event LogonCompleted(ByVal UserName As String)
        Sub CauseEvent()
            ' Raise an event on successful logon.
            RaiseEvent LogonCompleted("AustinSteele")
        End Sub
    End Class