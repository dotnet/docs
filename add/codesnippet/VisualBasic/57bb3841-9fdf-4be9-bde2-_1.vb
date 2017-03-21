   ' Invoked in case of events identified 
   ' by their event code.and related event 
   ' detailed code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, _
    ByVal eventCode As Integer, _
    ByVal detailedCode As Integer, _
    ByVal e As Exception)
        MyBase.New(msg, eventSource, _
        eventCode, detailedCode, e)
        ' Perform custom initialization.
        eventInfo = New StringBuilder()
        eventInfo.Append(String.Format( _
        "Event created at: ", _
        EventTime.ToString()))
    End Sub 'New
   
   