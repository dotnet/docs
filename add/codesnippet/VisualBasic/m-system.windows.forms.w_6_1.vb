    ' Navigates webBrowser1 to the home page of the current user.
    Private Sub homeButton_Click( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles homeButton.Click

        webBrowser1.GoHome()

    End Sub