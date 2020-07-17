'<Snippet1>
Imports System.Diagnostics
Imports System.Threading



Class Program
    Private Shared mySource As New TraceSource("TraceSourceApp")

    Shared Sub Main(ByVal args() As String)
        mySource.Switch = New SourceSwitch("sourceSwitch", "Error")
        mySource.Listeners.Remove("Default")
        Dim textListener As New TextWriterTraceListener("myListener.log")
        Dim console As New ConsoleTraceListener(False)
        console.Filter = New EventTypeFilter(SourceLevels.Information)
        console.Name = "console"
        textListener.Filter = New EventTypeFilter(SourceLevels.Error)
        mySource.Listeners.Add(console)
        mySource.Listeners.Add(textListener)
        Activity1()

        ' Allow the trace source to send messages to 
        ' listeners for all event types. Currently only 
        ' error messages or higher go to the listeners.
        ' Messages must get past the source switch to 
        ' get to the listeners, regardless of the settings 
        ' for the listeners.
        mySource.Switch.Level = SourceLevels.All

        ' Set the filter settings for the 
        ' console trace listener.
        mySource.Listeners("console").Filter = New EventTypeFilter(SourceLevels.Critical)
        Activity2()

        ' Change the filter settings for the console trace listener.
        mySource.Listeners("console").Filter = New EventTypeFilter(SourceLevels.Information)
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
        mySource.TraceInformation("Informational message.")

    End Sub

    Shared Sub Activity3()
        mySource.TraceEvent(TraceEventType.Error, 4, "Error message.")
        mySource.TraceInformation("Informational message.")

    End Sub
End Class

'</Snippet1>
