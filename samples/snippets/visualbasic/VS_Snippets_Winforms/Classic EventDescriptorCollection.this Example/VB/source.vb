Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected button1 As Button
    
    ' <Snippet1>
    Private Sub PrintIndexItem()
        ' Creates a new collection and assigns it the events for button1.
        Dim events As EventDescriptorCollection = TypeDescriptor.GetEvents(button1)
        
        ' Prints the second event's name.
        textBox1.Text = events(1).ToString()
    End Sub 'PrintIndexItem
    ' </Snippet1>
End Class 'Form1 

