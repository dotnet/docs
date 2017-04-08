Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected button1 As Button
    
    ' <Snippet1>
    Private Sub MyEventCollection()
        ' Creates a new collection and assigns it the events for button1.
        Dim events As EventDescriptorCollection = TypeDescriptor.GetEvents(button1)
        
        ' Displays each event in the collection in a text box.
        Dim myEvent As EventDescriptor
        For Each myEvent In  events
            textBox1.Text &= myEvent.Name & ControlChars.Cr
        Next myEvent
    End Sub 'MyEventCollection 
    ' </Snippet1>
End Class 'Form1 
