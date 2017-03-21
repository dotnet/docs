    // Updates the status bar with the current browser status text.
    private void webBrowser1_StatusTextChanged(object sender, EventArgs e)
    {
        toolStripStatusLabel1.Text = webBrowser1.StatusText;
    }