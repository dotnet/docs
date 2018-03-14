Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected button1 As Button
    Protected textBox1 As TextBox
    
' <Snippet1>
 Private Sub PrintIndexItem2()
     ' Creates a new collection and assigns it the properties for button1.
     Dim properties As PropertyDescriptorCollection = _
        TypeDescriptor.GetProperties(button1)
        
     ' Sets a PropertyDescriptor to the specific property.
     Dim myProperty As PropertyDescriptor = properties("Opacity")
        
     ' Prints the display name for the property.
     textBox1.Text = myProperty.DisplayName
 End Sub

' </Snippet1>
End Class

