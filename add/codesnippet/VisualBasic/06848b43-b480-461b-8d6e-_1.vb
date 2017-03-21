 ' Create a listener, which outputs to the console screen, and
 ' add it to the trace listeners. 
 Dim myWriter As New TextWriterTraceListener()
 myWriter.Writer = System.Console.Out
 Trace.Listeners.Add(myWriter)
