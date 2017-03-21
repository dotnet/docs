    ' Updates the status bar with the current browser status text.
    Private Sub webBrowser1_StatusTextChanged( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles webBrowser1.StatusTextChanged

        toolStripStatusLabel1.Text = webBrowser1.StatusText

    End Sub