    Private Sub CreateTextDataObject()
        ' Creates a new data object using a string.
        Dim myString As String = "My text string"
        Dim myDataObject As New DataObject(myString)
        
        ' Prints the string in a text box.
        textBox1.Text = myDataObject.GetData(DataFormats.Text).ToString()
    End Sub 'CreateTextDataObject