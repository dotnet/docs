    Private Sub PrintIndexItem2()
        ' Creates a new collection and assigns it the events for button1.
        Dim events As EventDescriptorCollection = TypeDescriptor.GetEvents(button1)
        
        ' Sets an EventDescriptor to the specific event.
        Dim myEvent As EventDescriptor = events("KeyDown")
        
        ' Prints the name of the event.
        textBox1.Text = myEvent.Name
    End Sub 'PrintIndexItem2