    ' This example uses the DoubleClick event of a ListBox to load text files  
    ' listed in the ListBox into a TextBox control. This example
    ' assumes that the ListBox, named listBox1, contains a list of valid file 
    ' names with path and that this event handler method
    ' is connected to the DoublClick event of a ListBox control named listBox1.
    ' This example requires code access permission to access files.
    Private Sub listBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles listBox1.DoubleClick
        ' Get the name of the file to open from the ListBox.
        Dim file As [String] = listBox1.SelectedItem.ToString()

        Try
            ' Determine if the file exists before loading.
            If System.IO.File.Exists(file) Then
                ' Open the file and use a TextReader to read the contents into the TextBox.
                Dim myFile As New System.IO.FileInfo(listBox1.SelectedItem.ToString())
                Dim myData As System.IO.TextReader = myFile.OpenText()

                textBox1.Text = myData.ReadToEnd()
                myData.Close()
            End If
            ' Exception is thrown by the OpenText method of the FileInfo class.
        Catch
            MessageBox.Show("The file you specified does not exist.")
            ' Exception is thrown by the ReadToEnd method of the TextReader class.
        Catch
         MessageBox.Show("There was a problem loading the file into the TextBox. Ensure that the file is a valid text file.")
        End Try
    End Sub