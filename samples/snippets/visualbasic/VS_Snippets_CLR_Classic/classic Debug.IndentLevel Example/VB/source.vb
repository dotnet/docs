Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    
    Protected Sub Method()
        ' <Snippet1>
        Debug.WriteLine("List of errors:")
        Debug.Indent()
        Debug.WriteLine("Error 1: File not found")
        Debug.WriteLine("Error 2: Directory not found")
        Debug.Unindent()
        Debug.WriteLine("End of list of errors")
        ' </Snippet1>
    End Sub 'Method 
End Class 'Form1 
