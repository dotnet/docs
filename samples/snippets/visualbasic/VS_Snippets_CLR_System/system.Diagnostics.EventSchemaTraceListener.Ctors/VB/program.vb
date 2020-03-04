
Imports System.Diagnostics


Class Program
    
    Shared Sub Main(ByVal args() As String) 
        '<snippet1>
        Dim ts As New TraceSource("TestSource")
        ts.Listeners.Add(New EventSchemaTraceListener("TraceOutput.xml"))
        '</snippet1>    
    End Sub

    Shared Sub Main2(ByVal args() As String) 
        '<snippet2>
        Dim ts As New TraceSource("TestSource")
        ts.Listeners.Add(New EventSchemaTraceListener("TraceOutput.xml", "eventListener"))
        '</snippet2>
    End Sub

    Shared Sub Main3(ByVal args() As String)
        '<snippet3>
        Dim ts As New TraceSource("TestSource")
        ts.Listeners.Add(New EventSchemaTraceListener("TraceOutput.xml", "eventListener", 65536))
        '</snippet3>

    End Sub

    Shared Sub Main4(ByVal args() As String)
        '<snippet4>
        Dim ts As New TraceSource("TestSource")
        ts.Listeners.Add(New EventSchemaTraceListener("TraceOutput.xml", "eventListener", 65536, TraceLogRetentionOption.LimitedCircularFiles))
        '</snippet4>

    End Sub

    Shared Sub Main5(ByVal args() As String)
        '<snippet5>
        Dim ts As New TraceSource("TestSource")
        ts.Listeners.Add(New EventSchemaTraceListener("TraceOutput.xml", "eventListener", 65536, TraceLogRetentionOption.LimitedCircularFiles, 20480000))
        '</snippet5>

    End Sub
End Class