         ' Check whether source exist in event log.
         If False = EventLog.SourceExists(mySource) Then
            ' Create a new source in a specified log on a system.
            EventLog.CreateEventSource(mySource, myLog)
         End If
         ' Create an event log instance.
         myEventLog = New EventLog(myLog)
         ' Initialize source property of obtained instance.
         myEventLog.Source = mySource
         Select Case myIntLog
            Case 1
               ' Write an 'Error' entry in specified log of event log.
               myEventLog.WriteEntry(myMessage, EventLogEntryType.Error, myID)
            Case 2
               ' Write a 'Warning' entry in specified log of event log.
               myEventLog.WriteEntry(myMessage, EventLogEntryType.Warning, myID)
            Case 3
               ' Write an 'Information' entry in specified log of event log.
               myEventLog.WriteEntry(myMessage, EventLogEntryType.Information, myID)
            Case 4
               ' Write a 'FailureAudit' entry in specified log of event log.
               myEventLog.WriteEntry(myMessage, EventLogEntryType.FailureAudit, myID)
            Case 5
               ' Write a 'SuccessAudit' entry in specified log of event log.
               myEventLog.WriteEntry(myMessage, EventLogEntryType.SuccessAudit, myID)
            Case Else
               Console.WriteLine("Error: Failed to create an event in event log.")
         End Select
         Console.WriteLine("A new event in log '{0}' with ID '{1}' " + _
                  "is successfully written into event log.", myEventLog.Log, myID)