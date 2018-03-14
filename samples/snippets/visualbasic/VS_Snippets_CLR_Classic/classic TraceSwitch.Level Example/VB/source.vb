Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
' <Snippet1>
    ' Class-level declaration.
    ' Create a TraceSwitch to use in the entire application. 
    
    Private Shared mySwitch As New TraceSwitch("mySwitch", "Entire Application")
    
    Public Shared Sub MyMethod()
        ' Write the message if the TraceSwitch level is set to Error or higher.
        If mySwitch.TraceError Then
            Console.WriteLine("My error message.")
        End If 
        ' Write the message if the TraceSwitch level is set to Verbose.
        If mySwitch.TraceVerbose Then
            Console.WriteLine("My second error message.")
        End If
    End Sub
    
    Public Shared Sub Main()
        ' Run the method that prints error messages based on the switch level.
        MyMethod()
    End Sub

' </Snippet1>
End Class

