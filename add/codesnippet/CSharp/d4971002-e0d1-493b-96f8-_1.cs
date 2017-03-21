
            string sourceName = "SampleApplicationSource";
            if(EventLog.SourceExists(sourceName))
            {
    
                // Define an informational event and a warning event.

                // The message identifiers correspond to the message text in the
                // message resource file defined for the source.
                EventInstance myInfoEvent = new EventInstance(InformationMsgId, 0, EventLogEntryType.Information);
                EventInstance myWarningEvent = new EventInstance(WarningMsgId, 0, EventLogEntryType.Warning);

                // Insert the method name into the event log message.
                string [] insertStrings = {"EventLogSamples.WriteEventSample2"};
            
                // Write the events to the event log.

                EventLog.WriteEvent(sourceName, myInfoEvent); 

                // Append binary data to the warning event entry.
                byte [] binaryData = { 7, 8, 9, 10 };
                EventLog.WriteEvent(sourceName, myWarningEvent, binaryData, insertStrings); 
            }
            else 
            {
                Console.WriteLine("Warning - event source {0} not registered", 
                    sourceName);
            }