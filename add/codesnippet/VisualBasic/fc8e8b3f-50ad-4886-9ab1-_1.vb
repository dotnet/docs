    ' Invoked in case of events identified by their 
    ' event code.and related event detailed code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, _
    ByVal eventCode As Integer, _
    ByVal eventDetailCode As Integer)
        MyBase.New(msg, eventSource, _
        eventCode, eventDetailCode)
        ' Perform custom initialization.
        customCreatedMsg = String.Format( _
        "Event created at: {0}", DateTime.Now.TimeOfDay.ToString())

    End Sub 'New

