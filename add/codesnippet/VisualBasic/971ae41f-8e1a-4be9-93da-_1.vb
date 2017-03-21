   ' Invoked in case of events identified 
   ' only by their event code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, _
    ByVal eventCode As Integer, ByVal e As Exception)
        MyBase.New(msg, eventSource, eventCode, e)
        ' Perform custom initialization.
        eventInfo = New StringBuilder()
        eventInfo.Append(String.Format( _
        "Event created at: ", EventTime.ToString()))
    End Sub 'New
   