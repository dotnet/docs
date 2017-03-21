    // Navigates webBrowser1 to the next page in history.
    private void forwardButton_Click(object sender, EventArgs e)
    {
        webBrowser1.GoForward();
    }

    // Disables the Forward button at the end of navigation history.
    private void webBrowser1_CanGoForwardChanged(object sender, EventArgs e)
    {
        forwardButton.Enabled = webBrowser1.CanGoForward;
    }