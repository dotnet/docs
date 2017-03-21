        Dim ts As New TraceSource("TestSource")
        ts.Listeners.Add(New EventSchemaTraceListener("TraceOutput.xml"))