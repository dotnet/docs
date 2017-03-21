    ' Hides script errors without hiding other dialog boxes.
    Private Sub SuppressScriptErrorsOnly(ByVal browser As WebBrowser)

        ' Ensure that ScriptErrorsSuppressed is set to false.
        browser.ScriptErrorsSuppressed = False

        ' Handle DocumentCompleted to gain access to the Document object.
        AddHandler browser.DocumentCompleted, _
            AddressOf browser_DocumentCompleted

    End Sub

    Private Sub browser_DocumentCompleted(ByVal sender As Object, _
    ByVal e As WebBrowserDocumentCompletedEventArgs)

        AddHandler CType(sender, WebBrowser).Document.Window.Error, _
            AddressOf Window_Error

    End Sub

    Private Sub Window_Error(ByVal sender As Object, _
        ByVal e As HtmlElementErrorEventArgs)

        ' Ignore the error and suppress the error dialog box. 
        e.Handled = True

    End Sub