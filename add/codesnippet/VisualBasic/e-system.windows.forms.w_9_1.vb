    ' Navigates webBrowser1 to the next page in history.
    Private Sub forwardButton_Click( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles forwardButton.Click

        webBrowser1.GoForward()

    End Sub

    ' Disables the Forward button at the end of navigation history.
    Private Sub webBrowser1_CanGoForwardChanged( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles webBrowser1.CanGoForwardChanged

        forwardButton.Enabled = webBrowser1.CanGoForward

    End Sub