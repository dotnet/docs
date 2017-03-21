    Private Function GetNotificationType(ByVal flushInfo _
    As WebEventBufferFlushInfo) _
    As EventNotificationType
        Return flushInfo.NotificationType
    End Function 'GetNotificationType
