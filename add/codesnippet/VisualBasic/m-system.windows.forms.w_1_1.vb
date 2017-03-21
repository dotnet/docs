    ' Prints the current document Imports the current print settings.
    Private Sub printButton_Click( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles printButton.Click

        webBrowser1.Print()

    End Sub