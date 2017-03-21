    ' Displays the Print dialog box.
    Private Sub printToolStripMenuItem_Click( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles printToolStripMenuItem.Click

        webBrowser1.ShowPrintDialog()

    End Sub