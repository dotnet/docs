   ' Invoked in case of events 
   ' identified only by their event code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, _
    ByVal eventCode As Integer, _
    ByVal e As Exception)
        MyBase.New(msg, eventSource, _
        eventCode, e)
        ' Perform custom initialization.
        eventInfo = New StringBuilder()
        eventInfo.Append(String.Format( _
        "Event created at: ", _
        EventTime.ToString()))
    End Sub 'New
   