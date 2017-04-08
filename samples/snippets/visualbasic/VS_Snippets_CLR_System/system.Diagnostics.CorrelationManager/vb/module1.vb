 '<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Diagnostics
Imports System.Threading



Class Program
    
    'private static TraceSource ts;
    Shared Sub Main(ByVal args() As String) 
        '<Snippet2>
        Dim ts As New TraceSource("MyApp")
        Dim i As Integer = ts.Listeners.Add(New ConsoleTraceListener())
        ts.Listeners(i).TraceOutputOptions = TraceOptions.LogicalOperationStack
        ts.Switch = New SourceSwitch("MyAPP", "Verbose")
        ' Start the logical operation on the Main thread.
        Trace.CorrelationManager.StartLogicalOperation("MainThread")
        '</Snippet2>
        ts.TraceEvent(TraceEventType.Error, 1, "Trace an error event.")
        Dim t As New Thread(New ThreadStart(AddressOf ThreadProc))
        ' Start the worker thread.
        t.Start()
        ' Give the worker thread a chance to execute.
        Thread.Sleep(1000)
        Trace.CorrelationManager.StopLogicalOperation()
    
    End Sub 'Main
    
    Public Shared Sub ThreadProc() 
        Dim ts As New TraceSource("MyApp")
        Dim i As Integer = ts.Listeners.Add(New ConsoleTraceListener())
        ts.Listeners(i).TraceOutputOptions = TraceOptions.LogicalOperationStack
        ts.Switch = New SourceSwitch("MyAPP", "Verbose")
        ' Add another logical operation.
        Trace.CorrelationManager.StartLogicalOperation("WorkerThread")
        ts.TraceEvent(TraceEventType.Error, 1, "Trace an error event.")
        Trace.CorrelationManager.StopLogicalOperation()
    
    End Sub 'ThreadProc
End Class 'Program
' This sample generates the following output:
'MyApp Error: 1 : Trace an error event.
'    LogicalOperationStack=MainThread
'MyApp Error: 1 : Trace an error event.
'    LogicalOperationStack=WorkerThread, MainThread
'</Snippet1>