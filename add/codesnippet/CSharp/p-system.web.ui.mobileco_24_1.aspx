    public void Page_Load(object source, EventArgs e)
    {
        if (!IsPostBack)
        {
            string txt = "Selected Filter is {0}";
            Label1.Text = String.Format(txt, 
                Panel1.DeviceSpecific.SelectedChoice.Filter.ToString());
        }
    }