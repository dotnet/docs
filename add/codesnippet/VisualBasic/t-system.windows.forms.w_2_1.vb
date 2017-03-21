    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Load

        webBrowser1.DocumentText = _
            "<html><body>Please enter your name:<br/>" & _
            "<input type='text' name='userName'/><br/>" & _
            "<a href='http://www.microsoft.com'>continue</a>" & _
            "</body></html>"

    End Sub

    Private Sub webBrowser1_Navigating( _
        ByVal sender As Object, ByVal e As WebBrowserNavigatingEventArgs) _
        Handles webBrowser1.Navigating

        Dim document As System.Windows.Forms.HtmlDocument = _
            webBrowser1.Document
        If document IsNot Nothing And _
            document.All("userName") IsNot Nothing And _
            String.IsNullOrEmpty( _
            document.All("userName").GetAttribute("value")) Then

            e.Cancel = True
            MsgBox("You must enter your name before you can navigate to " & _
                e.Url.ToString())
        End If

    End Sub