Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    
    Protected Sub Method()
        ' <Snippet1>
        ' Create an index for an array.
        Dim index As Integer
        
        ' Perform some action that sets the index.
        index = -40
        
        ' Test that the index value is valid. 
        Debug.Assert((index > - 1))
        ' </Snippet1>
    End Sub 'Method
End Class 'Form1
