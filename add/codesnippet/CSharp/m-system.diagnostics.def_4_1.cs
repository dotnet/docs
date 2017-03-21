        // Remove the original default trace listener.
        Trace.Listeners.RemoveAt(0);

        // Create and add a new default trace listener.
        DefaultTraceListener defaultListener;
        defaultListener = new DefaultTraceListener();
        Trace.Listeners.Add(defaultListener);

        // Assign the log file specification from the command line, if entered.
        if (args.Length>=2)
        {
            defaultListener.LogFileName = args[1];
        }