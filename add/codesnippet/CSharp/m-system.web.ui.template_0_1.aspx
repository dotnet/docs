    void Page_Init(object sender, System.EventArgs e)
    {
        // Instantiate the UserControl object
        MyControl myControl1 =
            (MyControl)LoadControl("TempControl_Samples1.ascx.cs");
        PlaceHolder1.Controls.Add(myControl1);
    }