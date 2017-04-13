Imports System
Imports System.Data
Imports System.Diagnostics

Public Class Class1

    Public Sub Method()
        ' <Snippet1>
        ' Create a ConsoleTraceListener and add it to the trace listeners. 
        Dim myWriter As New ConsoleTraceListener()
        Trace.Listeners.Add(myWriter)

        ' </Snippet1>
    End Sub
End Class