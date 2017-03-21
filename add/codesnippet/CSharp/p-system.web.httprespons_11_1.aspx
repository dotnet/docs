    protected void Page_Load(object sender, EventArgs e)
    {
        // Show success or failure of page load.
        if (Response.StatusCode != 200)
        {
            Response.Write("There was a problem accessing the web resource" +
                "<br />" + Response.StatusDescription);
        }
    }