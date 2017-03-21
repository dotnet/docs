    public void Page_Load(Object source, EventArgs e)
    {
        if (Panel1.IsTemplated)
        {
            string txt = "Loaded panel has {0} Templates for a Filter named {1}.";
            Label1.Text = 
                String.Format(txt, 
                    Panel1.DeviceSpecific.Choices[0].Templates.Count, 
                    Panel1.DeviceSpecific.Choices[0].Filter.ToString());
        }
        else
        {
            Label1.Text = "Loaded panel does not have Templates";
        }
    }