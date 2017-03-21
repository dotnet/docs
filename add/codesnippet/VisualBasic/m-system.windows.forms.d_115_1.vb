    Private Sub GetIfPresent3()
        ' Creates a new data object using a string and the text format.
        Dim myDataObject As New DataObject(DataFormats.Text, "Another string")
        
        ' Prints the string in a text box with autoconvert = false.
        If myDataObject.GetDataPresent("System.String", False) Then
            ' Prints the string in a text box.
            textBox1.Text = myDataObject.GetData("System.String", False).ToString() & ControlChars.Cr
        Else
            textBox1.Text = "Could not convert data to specified format" & ControlChars.Cr
        End If 
        ' Prints the string in a text box with autoconvert = true.
        textBox1.Text &= "With autoconvert = true, you can convert text to string format. " & _
                        "String is: " & myDataObject.GetData("System.String", True).ToString()
    End Sub 'GetIfPresent3