
            // Create the event source if it does not exist.
            string sourceName = "SampleApplicationSource";
            if(!EventLog.SourceExists(sourceName))
            {
                // Call a local method to register the event log source
                // for the event log "myNewLog."  Use the resource file
                // EventLogMsgs.dll in the current directory for message text.

                string messageFile =  String.Format("{0}\\{1}", 
                    System.Environment.CurrentDirectory, 
                    "EventLogMsgs.dll");

                CreateEventSourceSample1(messageFile);
            }

            // Get the event log corresponding to the existing source.
            string myLogName = EventLog.LogNameFromSourceName(sourceName,".");
       
            EventLog myEventLog = new EventLog(myLogName, ".", sourceName);

            // Define two audit events.

            // The message identifiers correspond to the message text in the
            // message resource file defined for the source.
            EventInstance myAuditSuccessEvent = new EventInstance(AuditSuccessMsgId, 0, EventLogEntryType.SuccessAudit);
            EventInstance myAuditFailEvent = new EventInstance(AuditFailedMsgId, 0, EventLogEntryType.FailureAudit);

            // Insert the method name into the event log message.
            string [] insertStrings = {"EventLogSamples.WriteEventSample1"};
            
            // Write the events to the event log.

            myEventLog.WriteEvent(myAuditSuccessEvent, insertStrings); 

            // Append binary data to the audit failure event entry.
            byte [] binaryData = { 3, 4, 5, 6 };
            myEventLog.WriteEvent(myAuditFailEvent, binaryData, insertStrings); 
