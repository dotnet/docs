        ' Remove the original default trace listener.
        Trace.Listeners.RemoveAt(0)

        ' Create and add a new default trace listener.
        Dim defaultListener As DefaultTraceListener
        defaultListener = New DefaultTraceListener
        Trace.Listeners.Add(defaultListener)

        ' Assign the log file specification from the command line, if entered.
        If args.Length >= 2 Then
            defaultListener.LogFileName = args(1)
        End If