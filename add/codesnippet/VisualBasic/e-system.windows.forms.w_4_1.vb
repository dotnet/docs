    ' Updates the title bar with the current document title.
    Private Sub webBrowser1_DocumentTitleChanged( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles webBrowser1.DocumentTitleChanged

        Me.Text = webBrowser1.DocumentTitle

    End Sub