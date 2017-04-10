' <snippet6>
Imports System
Imports System.Diagnostics

Class OverviewTraceListener
    Public Shared Sub Main()
        ' <snippet7>
        ' Use this example when debugging.
        Debug.WriteLine("Error in Widget 42")
        ' Use this example when tracing.
        Trace.WriteLine("Error in Widget 42")
        ' </snippet7>

        ' <snippet8>
        Trace.Listeners.Clear()
        Trace.Listeners.Add(New TextWriterTraceListener(Console.Out))
        ' </snippet8>
    End Sub
End Class
' </snippet6>
