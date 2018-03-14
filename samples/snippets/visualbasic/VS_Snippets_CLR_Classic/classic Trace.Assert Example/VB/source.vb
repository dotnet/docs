Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
' <Snippet1>
    ' Create an index for an array.
    Protected index As Integer    
    
    Protected Sub Method()
        ' Perform some action that sets the index.
        ' Test that the index value is valid. 
        Trace.Assert(index > -1)
    End Sub

' </Snippet1>
End Class
