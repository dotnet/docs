    private void Form1_Load(object sender, EventArgs e)
    {
        webBrowser1.DocumentText =
            "<html><body>Please enter your name:<br/>" +
            "<input type='text' name='userName'/><br/>" +
            "<a href='http://www.microsoft.com'>continue</a>" +
            "</body></html>";
        webBrowser1.Navigating += 
            new WebBrowserNavigatingEventHandler(webBrowser1_Navigating);
    }

    private void webBrowser1_Navigating(object sender, 
        WebBrowserNavigatingEventArgs e)
    {
        System.Windows.Forms.HtmlDocument document =
            this.webBrowser1.Document;

        if (document != null && document.All["userName"] != null && 
            String.IsNullOrEmpty(
            document.All["userName"].GetAttribute("value")))
        {
            e.Cancel = true;
            System.Windows.Forms.MessageBox.Show(
                "You must enter your name before you can navigate to " +
                e.Url.ToString());
        }
    }