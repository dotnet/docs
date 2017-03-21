    ' Halts the current navigation and any sounds or animations on 
    ' the page.
    Private Sub stopButton_Click( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles stopButton.Click

        webBrowser1.Stop()

    End Sub