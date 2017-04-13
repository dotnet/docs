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
    
    Public Shared Sub MyErrorMethod(myObject As Object, category As String)
        ' Write the message if the TraceSwitch level is set to Verbose.
        If generalSwitch.TraceVerbose Then
            Trace.Write(myObject.ToString() & _
                " is not a valid object for category: ", category)
        End If
        
        ' Write a second message if the TraceSwitch level is set to Error or higher.
        If generalSwitch.TraceError Then
            Trace.WriteLine(" Please use a different category.")
        End If
    End Sub

' </Snippet1>
End Class
