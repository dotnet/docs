    ' Invoked in case of events identified only by their event code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, ByVal eventCode As Integer)
        MyBase.New(msg, eventSource, eventCode)
        ' Perform custom initialization.
        customCreatedMsg = String.Format("Event created at: {0}", _
        DateTime.Now.TimeOfDay.ToString())

    End Sub 'New
    