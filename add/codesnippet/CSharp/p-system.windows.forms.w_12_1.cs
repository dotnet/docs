    // Hides script errors without hiding other dialog boxes.
    private void SuppressScriptErrorsOnly(WebBrowser browser)
    {
        // Ensure that ScriptErrorsSuppressed is set to false.
        browser.ScriptErrorsSuppressed = false;

        // Handle DocumentCompleted to gain access to the Document object.
        browser.DocumentCompleted +=
            new WebBrowserDocumentCompletedEventHandler(
                browser_DocumentCompleted);
    }

    private void browser_DocumentCompleted(object sender, 
        WebBrowserDocumentCompletedEventArgs e)
    {
        ((WebBrowser)sender).Document.Window.Error += 
            new HtmlElementErrorEventHandler(Window_Error);
    }

    private void Window_Error(object sender, 
        HtmlElementErrorEventArgs e)
    {
        // Ignore the error and suppress the error dialog box. 
        e.Handled = true;
    }