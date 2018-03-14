Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected button1 As Button
    Protected textBox1 As TextBox
    
' <Snippet1>
 Private Sub GetCount()
     ' Creates a new collection and assign it the properties for button1.
     Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(button1)
        
     ' Prints the number of properties on button1 in a textbox.
     textBox1.Text = properties.Count.ToString()
 End Sub

' </Snippet1>
End Class

