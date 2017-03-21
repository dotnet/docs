    Private Function GetEvents( _
    ByVal flushInfo As WebEventBufferFlushInfo) _
    As WebBaseEventCollection
        Return flushInfo.Events
    End Function 'GetEvents
