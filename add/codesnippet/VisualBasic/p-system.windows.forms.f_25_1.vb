    Private Sub InitializeOpenFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog

        ' Set the file dialog to filter for graphics files.
        Me.OpenFileDialog1.Filter = _
        "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"

        ' Allow the user to select multiple images.
        Me.OpenFileDialog1.Multiselect = True
        Me.OpenFileDialog1.Title = "My Image Browser"
    End Sub

    Private Sub fileButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles FileButton.Click
        OpenFileDialog1.ShowDialog()
    End Sub
