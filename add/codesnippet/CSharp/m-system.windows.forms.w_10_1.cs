    // Reloads the current page.
    private void refreshButton_Click(object sender, EventArgs e)
    {
        // Skip refresh if about:blank is loaded to avoid removing
        // content specified by the DocumentText property.
        if (!webBrowser1.Url.Equals("about:blank"))
        {
            webBrowser1.Refresh();
        }
    }