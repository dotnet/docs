    ' Invoked in case of events identified only by their event code.
    Public Sub New(ByVal msg As String, ByVal eventSource _
    As Object, ByVal eventCode As Integer, _
    ByVal userName As String)
        MyBase.New(msg, eventSource, eventCode, userName)
        ' Perform custom initialization.
        customCreatedMsg = _
        String.Format("Event created at: {0}", _
        DateTime.Now.TimeOfDay.ToString())

    End Sub 'New
