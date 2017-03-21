    Private Function GetEventsDiscardedSinceLastNotification( _
    ByVal flushInfo _
    As WebEventBufferFlushInfo) As Integer
        Return flushInfo.EventsDiscardedSinceLastNotification
    End Function 'GetEventsDiscardedSinceLastNotification
