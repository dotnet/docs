    Private Sub CreateTextDataObject2()
        ' Creates a new data object using a string.
        Dim myString As String = "My next text string"
        Dim myDataObject As New DataObject("System.String", myString)
        
        ' Prints the string in a text box.
        textBox1.Text = myDataObject.GetData(DataFormats.Text).ToString()
    End Sub 'CreateTextDataObject2