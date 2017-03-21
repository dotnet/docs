    ' Displays the Save dialog box.
    Private Sub saveAsToolStripMenuItem_Click( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles saveAsToolStripMenuItem.Click

        webBrowser1.ShowSaveAsDialog()

    End Sub