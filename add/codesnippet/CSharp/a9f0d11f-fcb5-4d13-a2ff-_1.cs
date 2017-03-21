            TraceSource ts = new TraceSource("TestSource");
            ts.Listeners.Add(new EventSchemaTraceListener("TraceOutput.xml", "eventListener"));