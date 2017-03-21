    ' Navigates webBrowser1 to the search page of the current user.
    Private Sub searchButton_Click( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles searchButton.Click

        webBrowser1.GoSearch()

    End Sub