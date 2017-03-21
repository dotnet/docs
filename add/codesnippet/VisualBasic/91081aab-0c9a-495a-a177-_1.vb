    ' Processes the messages that have been buffered.
    ' It is called by the ASP.NET when the flushing of 
    ' the buffer is required according to the parameters 
    ' defined in the <bufferModes> element of the 
    ' <healthMonitoring> configuration section.
    Public Overrides Sub ProcessEventFlush(ByVal flushInfo _
    As WebEventBufferFlushInfo)

        ' Customize event information to be sent to 
        ' the Windows Event Viewer Application Log.
        customInfo.AppendLine( _
        "SampleEventLogWebEventProvider buffer flush.")

        customInfo.AppendLine(String.Format( _
        "NotificationType: {0}", _
        GetNotificationType(flushInfo)))

        customInfo.AppendLine(String.Format( _
        "EventsInBuffer: {0}", _
        GetEventsInBuffer(flushInfo)))

        customInfo.AppendLine(String.Format( _
        "EventsDiscardedSinceLastNotification: {0}", _
GetEventsDiscardedSinceLastNotification( _
flushInfo)))

        ' Read each buffered event and send it to the
        ' Application Log.
        Dim eventRaised As WebBaseEvent
        For Each eventRaised In flushInfo.Events
            customInfo.AppendLine(eventRaised.ToString())
        Next eventRaised
        ' Store the information in the specified file.
        StoreToFile(customInfo, logFilePath, _
        FileMode.Append)
    End Sub 'ProcessEventFlush
