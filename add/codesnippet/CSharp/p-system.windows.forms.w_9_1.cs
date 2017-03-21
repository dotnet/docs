    // Updates the title bar with the current document title.
    private void webBrowser1_DocumentTitleChanged(object sender, EventArgs e)
    {
        this.Text = webBrowser1.DocumentTitle;
    }