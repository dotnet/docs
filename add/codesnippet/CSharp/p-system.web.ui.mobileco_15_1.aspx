    void Page_Load(object sender, EventArgs e)
    {
        // Set the pager text properties
        if (!IsPostBack)
            Form1.PagerStyle.NextPageText = "Go Next >";
        else
        {
            // For postback, set different text
            Form1.PagerStyle.NextPageText = "Go More >";
            Form1.PagerStyle.PreviousPageText = "< Go Prev";
        }
    }