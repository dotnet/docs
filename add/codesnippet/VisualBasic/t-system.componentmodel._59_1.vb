    Private Sub MyEventCollection()
        ' Creates a new collection and assigns it the events for button1.
        Dim events As EventDescriptorCollection = TypeDescriptor.GetEvents(button1)
        
        ' Displays each event in the collection in a text box.
        Dim myEvent As EventDescriptor
        For Each myEvent In  events
            textBox1.Text &= myEvent.Name & ControlChars.Cr
        Next myEvent
    End Sub 'MyEventCollection 