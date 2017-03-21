   ' Processes the incoming events.
    ' This method performs custom 
    ' processing and, if buffering is 
    ' enabled, it calls the base.ProcessEvent
    ' to buffer the event information.
    Public Overrides Sub ProcessEvent( _
    ByVal eventRaised As WebBaseEvent)

        If UseBuffering Then
            ' Buffering enabled, call the base event to
            ' buffer event information.
            MyBase.ProcessEvent(eventRaised)
        Else
            ' Buffering disabled, store the current event
            ' now.
            customInfo.AppendLine("*** Buffering disabled ***")
            customInfo.AppendLine(eventRaised.ToString())
            ' Store the information in the specified file.
            StoreToFile(customInfo, _
            logFilePath, FileMode.Append)
        End If
    End Sub 'ProcessEvent
   