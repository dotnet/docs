   ' Invoked in case of events identified 
   ' by their event code.and 
   ' related event detailed code.
    Public Sub New(ByVal msg As String, ByVal eventSource _
    As Object, ByVal eventCode As Integer, _
    ByVal detailedCode As Integer, ByVal e As Exception)
        MyBase.New(msg, eventSource, _
        eventCode, detailedCode, e)
        ' Perform custom initialization.
        eventInfo = New StringBuilder()
        eventInfo.Append(String.Format( _
        "Event created at: ", EventTime.ToString()))
    End Sub 'New
   
   