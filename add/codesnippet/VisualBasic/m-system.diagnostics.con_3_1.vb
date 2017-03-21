        ' Define a trace listener to direct trace output from this method
        ' to the console.
        Dim consoleTracer As ConsoleTraceListener

        ' Check the command line arguments to determine which
        ' console stream should be used for trace output.
        If (CmdArgs.Length > 0) AndAlso _
           (CmdArgs(0).ToLower.Equals("/stderr")) Then
            ' Initialize the console trace listener to write
            ' trace output to the standard error stream.
            consoleTracer = New ConsoleTraceListener(True)
        Else
            ' Initialize the console trace listener to write
            ' trace output to the standard output stream.
            consoleTracer = New ConsoleTraceListener
        End If
        ' Set the name of the trace listener, which helps identify this 
        ' particular instance within the trace listener collection.
        consoleTracer.Name = "mainConsoleTracer"

        ' Write the initial trace message to the console trace listener.
        consoleTracer.WriteLine(DateTime.Now.ToString() & " [" & _
             consoleTracer.Name & "] - Starting output to trace listener.")

        ' Add the new console trace listener to 
        ' the collection of trace listeners.
        Trace.Listeners.Add(consoleTracer)