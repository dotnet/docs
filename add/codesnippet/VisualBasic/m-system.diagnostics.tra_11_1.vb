    <[Event](1, Message:="Application Failure: {0}", Level:=EventLevel.Error, Keywords:=Keywords.Diagnostic)> _
    Public Sub Failure(ByVal message As String)
        WriteEvent(1, message)
    End Sub 'Failure