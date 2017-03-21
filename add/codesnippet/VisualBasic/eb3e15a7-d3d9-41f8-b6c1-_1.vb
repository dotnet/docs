    ' Invoked in case of events identified by their event code.and 
    ' event detailed code.
    Public Sub New(ByVal msg As String, ByVal eventSource As Object, _
    ByVal eventCode As Integer, ByVal detailedCode As Integer)
        MyBase.New(msg, EventSource, eventCode, detailedCode)
        ' Perform custom initialization.
        customCreatedMsg = String.Format("Event created at: {0}", _
        DateTime.Now.TimeOfDay.ToString())

    End Sub 'New
    
    