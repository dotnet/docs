
 TextWriterTraceListener myWriter = new TextWriterTraceListener();
    myWriter.Writer = System.Console.Out;
    Trace.Listeners.Add(myWriter);
    