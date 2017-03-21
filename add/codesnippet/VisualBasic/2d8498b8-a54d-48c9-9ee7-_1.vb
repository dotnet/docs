         ' Create the source, if it does not already exist.
         If Not EventLog.SourceExists("MySource") Then
            EventLog.CreateEventSource("MySource", "myNewLog")
            Console.WriteLine("Creating EventSource")
         End If
         
         ' Set the 'description' for the event.
         Dim myMessage As String = "This is my event."
         Dim myEventLogEntryType As EventLogEntryType = EventLogEntryType.Warning
         Dim myApplicationEventId As Integer = 100
         
         ' Write the entry in the event log.
         Console.WriteLine("Writing to EventLog.. ")
         EventLog.WriteEntry("MySource", myMessage, myEventLogEntryType, myApplicationEventId)