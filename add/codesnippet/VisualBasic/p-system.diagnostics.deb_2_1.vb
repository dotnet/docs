        ' Create a listener that outputs to the console screen, and 
        ' add it to the debug listeners. 
        Dim myWriter As New TextWriterTraceListener(System.Console.Out)
        Debug.Listeners.Add(myWriter)