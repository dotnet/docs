    Private Sub PrintHelpPage()

        ' Create a WebBrowser instance. 
        Dim webBrowserForPrinting As New WebBrowser()

        ' Add an event handler that prints the document after it loads.
        AddHandler webBrowserForPrinting.DocumentCompleted, New _
            WebBrowserDocumentCompletedEventHandler(AddressOf PrintDocument)

        ' Set the Url property to load the document.
        webBrowserForPrinting.Url = New Uri("\\myshare\help.html")

    End Sub

    Private Sub PrintDocument(ByVal sender As Object, _
        ByVal e As WebBrowserDocumentCompletedEventArgs)

        Dim webBrowserForPrinting As WebBrowser = CType(sender, WebBrowser)

        ' Print the document now that it is fully loaded.
        webBrowserForPrinting.Print()
        MessageBox.Show("print")

        ' Dispose the WebBrowser now that the task is complete. 
        webBrowserForPrinting.Dispose()

    End Sub