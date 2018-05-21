    ' Declare an event at module level.
    Event LogonCompleted(ByVal UserName As String)

    Sub Logon(ByVal UserName As String)
        ' Raise the event.
        RaiseEvent LogonCompleted(UserName)
    End Sub