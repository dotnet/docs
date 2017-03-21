        int myEventID = 20;
        short myCategory = 10;
        // Write an informational entry to the event log.
        Console.WriteLine("Write from first source ");
        EventLog.WriteEntry("FirstSource", "Writing warning to event log.",
                             EventLogEntryType.Information, myEventID, myCategory);