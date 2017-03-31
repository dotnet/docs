Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected button1 As Button
    Protected textBox1 As TextBox
    
' <Snippet1>
 Private Sub PrintIndexItem()
     ' Creates a new collection and assigns it the properties for button1.
     Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(button1)
        
     ' Prints the second property's name.
     textBox1.Text = properties(1).ToString()
 End Sub

' </Snippet1>
End Class

