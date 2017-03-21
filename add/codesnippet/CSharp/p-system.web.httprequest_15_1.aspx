    private void Page_Load(object sender, EventArgs e)
    {
        // Check whether the current request has been
        // authenticated. If it has not, redirect the 
        // user to the Login.aspx page.
        if (!Request.IsAuthenticated)
        {
            Response.Redirect("Login.aspx");
        }
    }