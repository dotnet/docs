    ' Reloads the current page.
    Private Sub refreshButton_Click( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles refreshButton.Click

        ' Skip refresh if about:blank is loaded to avoid removing
        ' content specified by the DocumentText property.
        If Not webBrowser1.Url.Equals("about:blank") Then
            webBrowser1.Refresh()
        End If

    End Sub