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
    
    
    Public Shared Sub MyErrorMethod(myObject As Object, category As String)
        ' Write the message if the TraceSwitch level is set to Verbose.
        Debug.WriteIf(generalSwitch.TraceVerbose, myObject, category)
        
        ' Write a second message if the TraceSwitch level is set to Error or higher.
        Debug.WriteLineIf(generalSwitch.TraceError, " Object is not valid for this category.")
    End Sub 'MyErrorMethod
    ' </Snippet1>
End Class 'Form1 

