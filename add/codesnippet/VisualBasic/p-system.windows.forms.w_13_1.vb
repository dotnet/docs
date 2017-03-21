    ' Navigates webBrowser1 to the previous page in the history.
    Private Sub backButton_Click( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles backButton.Click

        webBrowser1.GoBack()

    End Sub

    ' Disables the Back button at the beginning of the navigation history.
    Private Sub webBrowser1_CanGoBackChanged( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles webBrowser1.CanGoBackChanged

        backButton.Enabled = webBrowser1.CanGoBack

    End Sub