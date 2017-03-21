 Dim myWriter As New TextWriterTraceListener()
 myWriter.Writer = System.Console.Out
 Trace.Listeners.Add(myWriter)