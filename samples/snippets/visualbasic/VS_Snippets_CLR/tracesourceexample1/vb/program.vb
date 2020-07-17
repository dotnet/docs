'<Snippet1>
Imports System.Diagnostics

Class TraceTest

    Private Shared mySource As New TraceSource("TraceSourceApp")

    Shared Sub Main(ByVal args() As String)
        ' Issue an error and a warning message. Only the error message
        ' should be logged.
        Activity1()

        ' Save the original settings from the configuration file.
        Dim configFilter As EventTypeFilter = CType(mySource.Listeners("console").Filter, EventTypeFilter)

        ' Create a new event type filter that ensures 
        ' warning messages will be written.
        mySource.Listeners("console").Filter = New EventTypeFilter(SourceLevels.Warning)

        ' Allow the trace source to send messages to listeners 
        ' for all event types. This statement will override 
        ' any settings in the configuration file.
        ' If you do not change the switch level, the event filter
        ' changes have no effect.
        mySource.Switch.Level = SourceLevels.All

        ' Issue a warning and a critical message. Both should be logged.
        Activity2()

        ' Restore the original filter settings.
        mySource.Listeners("console").Filter = configFilter
        Activity3()
        mySource.Close()
        Return

    End Sub

    Shared Sub Activity1()
        mySource.TraceEvent(TraceEventType.Error, 1, "Error message.")
        mySource.TraceEvent(TraceEventType.Warning, 2, "Warning message.")

    End Sub

    Shared Sub Activity2()
        mySource.TraceEvent(TraceEventType.Critical, 3, "Critical message.")
        mySource.TraceEvent(TraceEventType.Warning, 2, "Warning message.")

    End Sub

    Shared Sub Activity3()
        mySource.TraceEvent(TraceEventType.Error, 4, "Error message.")
        mySource.TraceInformation("Informational message.")

    End Sub
End Class
'</Snippet1>
