Imports System
Imports System.Diagnostics

Public Class Sample
    
    Protected Sub Method()
' <Snippet1>
 Dim myWriter As New TextWriterTraceListener()
 myWriter.Writer = System.Console.Out
 Trace.Listeners.Add(myWriter)
' </Snippet1>
    End Sub
End Class
