    Private Sub MyEnumerator()
        ' Creates a new collection, and assigns to it the events for button1.
        Dim events As EventDescriptorCollection = TypeDescriptor.GetEvents(button1)
        
        ' Creates an enumerator.
        Dim ie As IEnumerator = events.GetEnumerator()
        
        ' Prints the name of each event in the collection.
        Dim myEvent As Object
        While ie.MoveNext() = True
            myEvent = ie.Current
            textBox1.Text += myEvent.ToString() & ControlChars.Cr
        End While
    End Sub 'MyEnumerator