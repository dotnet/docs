Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Public Sub Method()
' <Snippet1>
 ' Create a listener, which outputs to the console screen, and
 ' add it to the trace listeners. 
 Dim myWriter As New TextWriterTraceListener()
 myWriter.Writer = System.Console.Out
 Trace.Listeners.Add(myWriter)

' </Snippet1>        
    End Sub
End Class
