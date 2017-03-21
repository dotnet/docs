    Private Sub TestDataObject()
        ' Creates a new data object using a string and the Text format.
        Dim myString As New String("Hello World!")
        Dim myDataObject As New DataObject(DataFormats.Text, myString)

        ' Checks whether the data is present in the Text format and displays the result.
        If (myDataObject.GetDataPresent(DataFormats.Text)) Then
            MessageBox.Show("The stored data is in the Text format.", "Test Result")
        Else
            MessageBox.Show("The stored data is not in the Text format.", "Test Result")
        End If
    End Sub 'TestDataObject