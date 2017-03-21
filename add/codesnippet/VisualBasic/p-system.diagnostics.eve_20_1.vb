            ' Get the event log corresponding to the existing source.
            Dim myLogName As String = EventLog.LogNameFromSourceName(sourceName,".")
        
            ' Find each instance of a specific event log entry in a
            ' particular event log.

            Dim myEventLog As EventLog = new EventLog(myLogName, ".", sourceName)
            Dim count As Integer = 0

            Console.WriteLine("Searching event log entries for the event ID {0}...", _
               ServerConnectionDownMsgId.ToString())
            
            ' Search for the resource ID, display the event text,
            ' and display the number of matching entries.

            Dim entry As EventLogEntry
            For Each entry In  myEventLog.Entries
                If entry.InstanceId = ServerConnectionDownMsgId
                    count = count + 1
                    Console.WriteLine()
                    Console.WriteLine("Entry ID    = {0}", _
                        entry.InstanceId.ToString())
                    Console.WriteLine("Reported at {0}", _
                        entry.TimeWritten.ToString())
                    Console.WriteLine("Message text:")
                    Console.WriteLine(ControlChars.Tab + entry.Message)
                End If
            Next entry

            Console.WriteLine()
            Console.WriteLine("Found {0} events with ID {1} in event log {2}", _
                count.ToString(), ServerConnectionDownMsgId.ToString(), myLogName)
