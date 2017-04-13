' <snippet2>
Imports System
Imports System.Diagnostics

Class InitTraceListener
    Public Shared Sub Main()
        ' <snippet4>
        Trace.Listeners.Add(new TextWriterTraceListener("TextWriterOutput.log", "myListener"))
        ' <snippet3>
        Trace.TraceInformation("Test message.")
        ' You must close or flush the trace to empty the output buffer.
        Trace.Flush()
        ' </snippet3>
        ' </snippet4>
        Trace.Close()

        ' <snippet5>
        Dim myListener As New TextWriterTraceListener("TextWriterOutput.log", "myListener")
        myListener.WriteLine("Test message.")
        ' You must close or flush the trace listener to empty the output buffer.
        myListener.Flush()
        ' </snippet5>
        myListener.Close()
    End Sub
End Class
' </snippet2>
