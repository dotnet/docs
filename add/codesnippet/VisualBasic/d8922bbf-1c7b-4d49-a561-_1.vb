    Private Sub FindEvent()
        ' Creates a new collection and assigns it the events for button1.
        Dim events As EventDescriptorCollection = TypeDescriptor.GetEvents(button1)
        
        ' Sets an EventDescriptor to the specific event.
        Dim myEvent As EventDescriptor = events.Find("Resize", False)
        
        ' Prints the event name and event description.
        textBox1.Text = myEvent.Name & ": " & myEvent.Description
    End Sub 'FindEvent