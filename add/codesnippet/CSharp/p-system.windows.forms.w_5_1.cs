    // Navigates to the URL in the address box when 
    // the ENTER key is pressed while the ToolStripTextBox has focus.
    private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Navigate(toolStripTextBox1.Text);
        }
    }

    // Navigates to the URL in the address box when 
    // the Go button is clicked.
    private void goButton_Click(object sender, EventArgs e)
    {
        Navigate(toolStripTextBox1.Text);
    }

    // Navigates to the given URL if it is valid.
    private void Navigate(String address)
    {
        if (String.IsNullOrEmpty(address)) return;
        if (address.Equals("about:blank")) return;
        if (!address.StartsWith("http://") &&
            !address.StartsWith("https://"))
        {
            address = "http://" + address;
        }
        try
        {
            webBrowser1.Navigate(new Uri(address));
        }
        catch (System.UriFormatException)
        {
            return;
        }
    }

    // Updates the URL in TextBoxAddress upon navigation.
    private void webBrowser1_Navigated(object sender,
        WebBrowserNavigatedEventArgs e)
    {
        toolStripTextBox1.Text = webBrowser1.Url.ToString();
    }