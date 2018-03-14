Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected button1 As Button
    
    
    Protected Sub Method()
        ' <Snippet1>
        Dim events As EventDescriptorCollection = TypeDescriptor.GetEvents(button1)
        ' </Snippet1>
    End Sub 'Method 
End Class 'Form1 
