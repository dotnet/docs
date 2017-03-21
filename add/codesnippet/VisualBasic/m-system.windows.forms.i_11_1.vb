    Private Sub GetData1()
        ' Creates a new data object using a string and the text format.
        Dim myString As String = "My text string"
        Dim myDataObject As New DataObject(DataFormats.Text, myString)

        ' Displays the string in a text box.
        textBox1.Text = myDataObject.GetData(DataFormats.Text).ToString()
    End Sub 'GetData1