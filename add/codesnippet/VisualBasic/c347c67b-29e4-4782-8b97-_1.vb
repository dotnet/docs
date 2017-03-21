    <EventSource(Name:="Litware-ProductName-ComponentName")> _
    Public NotInheritable Class LitwareComponentNameEventSource
        Inherits EventSource
        <[Event](1, Task:=Tasks.Request, Opcode:=EventOpcode.Send)> _
        Public Sub RequestStart(relatedActivityId As Guid, reqId As Integer, url As String)
            WriteEventWithRelatedActivityId(1, relatedActivityId, reqId, url)
        End Sub

    End Class
