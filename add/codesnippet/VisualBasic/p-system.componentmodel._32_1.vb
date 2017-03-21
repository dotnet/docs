    Private Sub GetCount()
        ' Creates a new collection and assigns it the events for button1.
        Dim events As EventDescriptorCollection = TypeDescriptor.GetEvents(button1)
        
        ' Prints the number of events on button1 in a text box.
        textBox1.Text = events.Count.ToString()
    End Sub 'GetCount