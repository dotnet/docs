    ' Displays the Print Preview dialog box.
    Private Sub printPreviewToolStripMenuItem_Click( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles printPreviewToolStripMenuItem.Click

        webBrowser1.ShowPrintPreviewDialog()

    End Sub