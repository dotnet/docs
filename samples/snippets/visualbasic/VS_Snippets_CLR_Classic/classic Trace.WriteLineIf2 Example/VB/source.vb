Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
' <Snippet1>
    ' Class-level declaration.
    ' Create a TraceSwitch.
    Private Shared generalSwitch As New TraceSwitch("General", "Entire Application")
    
    Public Shared Sub MyErrorMethod(category As String)
        ' Write the message if the TraceSwitch level is set to Error or higher.
        Trace.WriteIf(generalSwitch.TraceError, "My error message. ")
        
        ' Write a second message if the TraceSwitch level is set to Verbose.
        Trace.WriteLineIf(generalSwitch.TraceVerbose, _
            "My second error message.", category)
    End Sub

' </Snippet1>
End Class

