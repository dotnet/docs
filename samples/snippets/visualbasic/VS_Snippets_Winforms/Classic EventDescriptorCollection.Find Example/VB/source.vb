Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected button1 As Button
    
    ' <Snippet1>
    Private Sub FindEvent()
        ' Creates a new collection and assigns it the events for button1.
        Dim events As EventDescriptorCollection = TypeDescriptor.GetEvents(button1)
        
        ' Sets an EventDescriptor to the specific event.
        Dim myEvent As EventDescriptor = events.Find("Resize", False)
        
        ' Prints the event name and event description.
        textBox1.Text = myEvent.Name & ": " & myEvent.Description
    End Sub 'FindEvent
    ' </Snippet1>
End Class 'Form1 

