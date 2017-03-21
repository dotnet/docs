        Dim ts As New TraceSource("MyApp")
        Dim i As Integer = ts.Listeners.Add(New ConsoleTraceListener())
        ts.Listeners(i).TraceOutputOptions = TraceOptions.LogicalOperationStack
        ts.Switch = New SourceSwitch("MyAPP", "Verbose")
        ' Start the logical operation on the Main thread.
        Trace.CorrelationManager.StartLogicalOperation("MainThread")