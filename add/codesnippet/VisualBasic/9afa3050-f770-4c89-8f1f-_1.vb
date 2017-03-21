            ' Issue file not found message as a verbose event using a formatted string.
            ts.TraceEvent(TraceEventType.Verbose, 3, "File {0} not found.", "test")