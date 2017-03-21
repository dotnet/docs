    // Navigates webBrowser1 to the previous page in the history.
    private void backButton_Click(object sender, EventArgs e)
    {
        webBrowser1.GoBack();
    }

    // Disables the Back button at the beginning of the navigation history.
    private void webBrowser1_CanGoBackChanged(object sender, EventArgs e)
    {
        backButton.Enabled = webBrowser1.CanGoBack;
    }