
    ' Navigates to the URL in the address box when 
    ' the ENTER key is pressed while the ToolStripTextBox has focus.
    Private Sub toolStripTextBox1_KeyDown( _
        ByVal sender As Object, ByVal e As KeyEventArgs) _
        Handles toolStripTextBox1.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            Navigate(toolStripTextBox1.Text)
        End If

    End Sub

    ' Navigates to the URL in the address box when 
    ' the Go button is clicked.
    Private Sub goButton_Click( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles goButton.Click

        Navigate(toolStripTextBox1.Text)

    End Sub

    ' Navigates to the given URL if it is valid.
    Private Sub Navigate(ByVal address As String)

        If String.IsNullOrEmpty(address) Then Return
        If address.Equals("about:blank") Then Return
        If Not address.StartsWith("http://") And _
            Not address.StartsWith("https://") Then
            address = "http://" & address
        End If

        Try
            webBrowser1.Navigate(New Uri(address))
        Catch ex As System.UriFormatException
            Return
        End Try

    End Sub

    ' Updates the URL in TextBoxAddress upon navigation.
    Private Sub webBrowser1_Navigated(ByVal sender As Object, _
        ByVal e As WebBrowserNavigatedEventArgs) _
        Handles webBrowser1.Navigated

        toolStripTextBox1.Text = webBrowser1.Url.ToString()

    End Sub