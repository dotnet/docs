            Dim sourceName As String = "SampleApplicationSource"
            If EventLog.SourceExists(sourceName)
   
                ' Define an informational event and a warning event.

                ' The message identifiers correspond to the message text in the
                ' message resource file defined for the source.
                Dim myInfoEvent As EventInstance = new EventInstance(InformationMsgId, 0, EventLogEntryType.Information)
                Dim myWarningEvent As EventInstance = new EventInstance(WarningMsgId, 0, EventLogEntryType.Warning)

                ' Insert the method name into the event log message.
                Dim insertStrings() As String = {"EventLogSamples.WriteEventSample2"}
            
                ' Write the events to the event log.

                EventLog.WriteEvent(sourceName, myInfoEvent, insertStrings)

                ' Append binary data to the warning event entry.
                Dim binaryData() As Byte = { 7, 8, 9, 10 }
                EventLog.WriteEvent(sourceName, myWarningEvent, binaryData, insertStrings)
            Else 
                Console.WriteLine("Warning - event source {0} not registered", _
                    sourceName)
            End If
 