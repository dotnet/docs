    Private Sub button2_Click(sender As Object, e As System.EventArgs)
        ' Declares an IDataObject to hold the data returned from the clipboard.
        ' Retrieves the data from the clipboard.
        Dim iData As IDataObject = Clipboard.GetDataObject()
        
        ' Determines whether the data is in a format you can use.
        If iData.GetDataPresent(DataFormats.Text) Then
            ' Yes it is, so display it in a text box.
            textBox2.Text = CType(iData.GetData(DataFormats.Text), String)
        Else
            ' No it is not.
            textBox2.Text = "Could not retrieve data off the clipboard."
        End If
    End Sub 'button2_Click