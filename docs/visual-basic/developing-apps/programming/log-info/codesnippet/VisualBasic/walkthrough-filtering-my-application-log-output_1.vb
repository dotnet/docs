        ' Activity tracing information
        My.Application.Log.WriteEntry("Entering Button1_Click", TraceEventType.Start)

        ' Tracing information
        My.Application.Log.WriteEntry("In Button1_Click", TraceEventType.Information)

        ' Create an exception to log.
        Dim ex As New ApplicationException
        ' Exception information
        My.Application.Log.WriteException(ex)

        ' Activity tracing information
        My.Application.Log.WriteEntry("Leaving Button1_Click", TraceEventType.Stop)