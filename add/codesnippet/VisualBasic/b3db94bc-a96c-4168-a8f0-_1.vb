        ' Create an EventLog instance and assign its source.
        Dim myLog As New EventLog()
        myLog.Source = "ThirdSource"

        ' Write an informational entry to the event log.
        Console.WriteLine("Write from third source ")
        myLog.WriteEntry("Writing warning to event log.", EventLogEntryType.Warning, _
                             myEventID, myCategory)