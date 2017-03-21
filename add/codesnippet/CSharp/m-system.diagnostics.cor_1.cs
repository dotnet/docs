            TraceSource ts = new TraceSource("MyApp");
            int i = ts.Listeners.Add(new ConsoleTraceListener());
            ts.Listeners[i].TraceOutputOptions = TraceOptions.LogicalOperationStack;
            ts.Switch = new SourceSwitch("MyAPP", "Verbose");
            // Start the logical operation on the Main thread.
            Trace.CorrelationManager.StartLogicalOperation("MainThread");