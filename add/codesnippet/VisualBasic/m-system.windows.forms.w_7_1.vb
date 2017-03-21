    ' Displays the Page Setup dialog box.
    Private Sub pageSetupToolStripMenuItem_Click( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles pageSetupToolStripMenuItem.Click

        webBrowser1.ShowPageSetupDialog()

    End Sub