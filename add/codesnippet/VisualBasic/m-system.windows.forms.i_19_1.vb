    Private Sub GetDataPresent3()
        ' Creates a new data object using a string and the Text format.
        Dim myDataObject As New DataObject(DataFormats.Text, "My String")

        ' Checks whether the string can be displayed with autoConvert equal to false.
        If myDataObject.GetDataPresent("System.String", False) Then
            MessageBox.Show(myDataObject.GetData("System.String", False).ToString() + ".", "Message #1")
        Else
            MessageBox.Show("Cannot convert data to the specified format with autoConvert set to false.", "Message #1")
        End If
        ' Displays the string with autoConvert equal to true.
        MessageBox.Show(("Now that autoConvert is true, you can convert " + myDataObject.GetData("System.String", _
             True).ToString() + " to string format."), "Message #2")

    End Sub 'GetDataPresent3