    Private Sub CreateDefaultDataObject()
        ' Creates a data object.
        Dim myDataObject As DataObject
        
        ' Assigns the string to the data object.
        Dim myString As String = "My text string"
        myDataObject = New DataObject(myString)
        
        ' Prints the string in a text box.
        textBox1.Text = myDataObject.GetData(DataFormats.Text).ToString()
    End Sub 'CreateDefaultDataObject