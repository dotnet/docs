  protected void Text_Change(object sender, EventArgs e)
  {
    myLabel.Text = "<b>Welcome " + myTextBox.Text + " to ASP.NET</b>";
  }

  protected void Page_PreRender(object sender, EventArgs e)
  {
    this.RegisterRequiresPostBack(myTextBox);
  }