    Overloads Public Shared Sub Main(args() As String)
       
        ' Create a trace listener for the event log.
        Dim myTraceListener As New EventLogTraceListener("myEventLogSource")
        
        ' Add the event log trace listener to the collection.
        Trace.Listeners.Add(myTraceListener)
        
        ' Write output to the event log.
        Trace.WriteLine("Test output")
    End Sub 'Main