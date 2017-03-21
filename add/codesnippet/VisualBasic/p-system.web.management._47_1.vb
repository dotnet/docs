    Private Function GetLastNotificationTime(ByVal flushInfo _
    As WebEventBufferFlushInfo) As DateTime
        Return flushInfo.LastNotificationUtc
    End Function 'GetLastNotificationTime
