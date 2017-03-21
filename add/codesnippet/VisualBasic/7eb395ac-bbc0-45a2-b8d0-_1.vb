    ' Chek if the specified event is in the collection.
    Public Shared Function ContainsEvent(ByVal ev _
    As WebBaseEvent) As Boolean
        Return events.Contains(ev)

    End Function 'ContainsEvent
    