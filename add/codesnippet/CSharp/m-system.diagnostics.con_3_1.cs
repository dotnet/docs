        // Define a trace listener to direct trace output from this method
        // to the console.
        ConsoleTraceListener consoleTracer;

        // Check the command line arguments to determine which
        // console stream should be used for trace output.
        if ((CmdArgs.Length>0)&&(CmdArgs[0].ToString().ToLower().Equals("/stderr")))
            // Initialize the console trace listener to write
            // trace output to the standard error stream.
        {
            consoleTracer = new ConsoleTraceListener(true);
        }
        else
        {
            // Initialize the console trace listener to write
            // trace output to the standard output stream.
            consoleTracer = new ConsoleTraceListener();
        }
        // Set the name of the trace listener, which helps identify this 
        // particular instance within the trace listener collection.
        consoleTracer.Name = "mainConsoleTracer";

        // Write the initial trace message to the console trace listener.
        consoleTracer.WriteLine(DateTime.Now.ToString()+" ["+consoleTracer.Name+"] - Starting output to trace listener.");

        // Add the new console trace listener to 
        // the collection of trace listeners.
        Trace.Listeners.Add(consoleTracer);