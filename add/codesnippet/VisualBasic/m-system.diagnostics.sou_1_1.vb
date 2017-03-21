            ' Test the filter on the ConsoleTraceListener.
            ts.Listeners("console").Filter = New SourceFilter("No match")
            ts.TraceData(TraceEventType.Information, 5, "SourceFilter should reject this message for the console trace listener.")
            ts.Listeners("console").Filter = New SourceFilter("TraceTest")
            ts.TraceData(TraceEventType.Information, 6, "SourceFilter should let this message through on the console trace listener.")