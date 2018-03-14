Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    ' <Snippet1>
    ' Class-level declaration.
    ' Create a TraceSwitch.
    Private Shared generalSwitch As New TraceSwitch("General", "Entire Application")
    
    
    Public Shared Sub MyErrorMethod(myObject As Object)
        ' Write the message if the TraceSwitch level is set to Error or higher.
        Debug.WriteIf(generalSwitch.TraceError, "Invalid object. ")
        
        ' Write a second message if the TraceSwitch level is set to Verbose.
        Debug.WriteLineIf(generalSwitch.TraceVerbose, myObject)
    End Sub 'MyErrorMethod
    ' </Snippet1>
End Class 'Form1 

