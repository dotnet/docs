Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Public Sub Method()
' <Snippet1>
 Trace.WriteLine("List of errors:")
 Trace.Indent()
 Trace.WriteLine("Error 1: File not found")
 Trace.WriteLine("Error 2: Directory not found")
 Trace.Unindent()
 Trace.WriteLine("End of list of errors")

' </Snippet1>
    End Sub
End Class
