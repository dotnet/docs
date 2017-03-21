    Private Sub TextBox1_Validating(ByVal sender As Object, _
    ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles TextBox1.Validating

        ' If nothing is entered,
        ' an ArgumentException is caught; if an invalid directory is entered, 
        ' a DirectoryNotFoundException is caught. An appropriate error message 
        ' is displayed in either case.
        Try
            Dim directory As New System.IO.DirectoryInfo(TextBox1.Text)
            directory.GetFiles()
            ErrorProvider1.SetError(TextBox1, "")

        Catch ex1 As System.ArgumentException
            ErrorProvider1.SetError(TextBox1, "Please enter a directory")

        Catch ex2 As System.IO.DirectoryNotFoundException
            ErrorProvider1.SetError(TextBox1, _
            "The directory does not exist." & _
            "Try again with a different directory.")
        End Try

    End Sub

    ' This method handles the LostFocus event for TextBox1 by setting the 
    ' dialog's InitialDirectory property to the text in TextBox1.
    Private Sub TextBox1_LostFocus(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        OpenFileDialog1.InitialDirectory = TextBox1.Text
    End Sub


    ' This method demonstrates using the ErrorProvider.GetError method 
    ' to check for an error before opening the dialog box.
    Private Sub Button1_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles Button1.Click

        'If there is no error, then open the dialog box.
        If ErrorProvider1.GetError(TextBox1) = "" Then
            Dim dialogResult As DialogResult = OpenFileDialog1.ShowDialog()
        End If

    End Sub