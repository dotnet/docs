    private void PrintHelpPage()
    {
        // Create a WebBrowser instance. 
        WebBrowser webBrowserForPrinting = new WebBrowser();

        // Add an event handler that prints the document after it loads.
        webBrowserForPrinting.DocumentCompleted +=
            new WebBrowserDocumentCompletedEventHandler(PrintDocument);

        // Set the Url property to load the document.
        webBrowserForPrinting.Url = new Uri(@"\\myshare\help.html");
    }

    private void PrintDocument(object sender,
        WebBrowserDocumentCompletedEventArgs e)
    {
        // Print the document now that it is fully loaded.
        ((WebBrowser)sender).Print();

        // Dispose the WebBrowser now that the task is complete. 
        ((WebBrowser)sender).Dispose();
    }