Public Class Form1
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'My.Application.Log.WriteEntry("Critical", TraceEventType.Critical)
        'My.Application.Log.WriteEntry("Error", TraceEventType.Error)
        'My.Application.Log.WriteEntry("Information", TraceEventType.Information)
        'My.Application.Log.WriteEntry("Start", TraceEventType.Start)
        'My.Application.Log.WriteEntry("Start", TraceEventType.Start)
        'My.Application.Log.WriteEntry("Stop", TraceEventType.Stop)
        'My.Application.Log.WriteEntry("Suspend", TraceEventType.Suspend)
        'My.Application.Log.WriteEntry("Transfer", TraceEventType.Transfer)
        'My.Application.Log.WriteEntry("Verbose", TraceEventType.Verbose)
        'My.Application.Log.WriteEntry("Warning", TraceEventType.Warning)

        '     Dim xx As Microsoft.VisualBasic.Logging.FileLogTraceListener
        '    xx.Location = Logging.LogFileLocation.Custom
        '<snippet1>
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
        '</snippet1>

        '<snippet2>
        My.Application.Log.WriteEntry("Log entry")
        '</snippet2>
    End Sub
End Class
