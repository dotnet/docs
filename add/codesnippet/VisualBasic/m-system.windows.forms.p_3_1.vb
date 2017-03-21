    Private Sub startLoadButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles startLoadButton.Click

        ' Ensure WaitOnLoad is false.
        pictureBox1.WaitOnLoad = False

        ' Load the image asynchronously.
        pictureBox1.LoadAsync("http://localhost/print.gif")

    End Sub
    