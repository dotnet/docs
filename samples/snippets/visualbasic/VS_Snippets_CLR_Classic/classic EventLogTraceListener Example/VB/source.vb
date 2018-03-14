Imports System
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    ' <Snippet1>
    Overloads Public Shared Sub Main(args() As String)
       
        ' Create a trace listener for the event log.
        Dim myTraceListener As New EventLogTraceListener("myEventLogSource")
        
        ' Add the event log trace listener to the collection.
        Trace.Listeners.Add(myTraceListener)
        
        ' Write output to the event log.
        Trace.WriteLine("Test output")
    End Sub 'Main
    ' </Snippet1>
End Class 'Form1 
