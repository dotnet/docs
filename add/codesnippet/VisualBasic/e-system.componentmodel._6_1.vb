    ' Create a new part from the text in the two text boxes.
    Private Sub listOfParts_AddingNew(ByVal sender As Object, _
        ByVal e As AddingNewEventArgs) Handles listOfParts.AddingNew
        e.NewObject = New Part(textBox1.Text, Integer.Parse(textBox2.Text))

    End Sub
