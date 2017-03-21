    Private Sub GetData3()
        ' Creates a new data object using a text string.
        Dim myString As String = "Hello World!"
        Dim myDataObject As New DataObject(DataFormats.Text, myString)

        ' Displays the string with autoConvert equal to false.
        If (myDataObject.GetData("System.String", False) IsNot Nothing) Then
            ' Displays the string in a message box.
            MessageBox.Show(myDataObject.GetData("System.String", False).ToString() + ".", "Message #1")
            ' Displays a not found message in a message box.
        Else
            MessageBox.Show("Could not find data of the specified format.", "Message #1")
        End If

        ' Displays the string in a text box with autoConvert equal to true.
        Dim myData As String = "The data is " + myDataObject.GetData("System.String", True).ToString()
        MessageBox.Show(myData, "Message #2")
    End Sub 'GetData3