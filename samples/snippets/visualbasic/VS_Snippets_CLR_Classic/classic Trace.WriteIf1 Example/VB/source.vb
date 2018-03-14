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
    
    Public Shared Sub MyErrorMethod(myObject As Object)
        ' Write the message if the TraceSwitch level is set to Error or higher.
        Trace.WriteIf(generalSwitch.TraceError, myObject)
        
        ' Write a second message if the TraceSwitch level is set to Verbose.
        Trace.WriteLineIf(generalSwitch.TraceVerbose, _
            " is not a valid value for this method.")
    End Sub

' </Snippet1>
End Class

