        Dim myEventID As Integer = 10
        Dim myCategory As Short = 20
        ' Write an informational entry to the event log.
        Console.WriteLine("Write from first source ")
        EventLog.WriteEntry("FirstSource", "Writing warning to event log.", _
                                   EventLogEntryType.Information, myEventID, myCategory)