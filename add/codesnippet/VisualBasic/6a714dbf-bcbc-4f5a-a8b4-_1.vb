
            Dim sourceName As String = "SampleApplicationSource"

            ' Create the event source if it does not exist.
            If Not EventLog.SourceExists(sourceName)
   
                ' Call a local method to register the event log source
                ' for the event log "myNewLog."  Use the resource file
                ' EventLogMsgs.dll in the current directory for message text.

                Dim messageFile As String =  String.Format("{0}\\{1}", _
                    System.Environment.CurrentDirectory, _
                    "EventLogMsgs.dll")

                CreateEventSourceSample1(messageFile)
            End If 

            ' Get the event log corresponding to the existing source.
            Dim myLogName As String = EventLog.LogNameFromSourceName(sourceName,".")
        
            Dim myEventLog As EventLog = new EventLog(myLogName, ".", sourceName)

            ' Define two audit events.
            Dim myAuditSuccessEvent As EventInstance = new EventInstance(AuditSuccessMsgId, 0, EventLogEntryType.SuccessAudit)
            Dim myAuditFailEvent As EventInstance = new EventInstance(AuditFailedMsgId, 0, EventLogEntryType.FailureAudit)

            ' Insert the method name into the event log message.
            Dim insertStrings() As String = {"EventLogSamples.WriteEventSample1"}
            
            ' Write the events to the event log.

            myEventLog.WriteEvent(myAuditSuccessEvent, insertStrings)

            ' Append binary data to the audit failure event entry.
            Dim binaryData() As Byte = { 7, 8, 9, 10 }
            myEventLog.WriteEvent(myAuditFailEvent, binaryData, insertStrings)
 