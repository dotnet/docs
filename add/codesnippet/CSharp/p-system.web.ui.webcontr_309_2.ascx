  // Update the selected IWebPart property value.
  void Button1_Click(object sender, EventArgs e)
  {
    String propertyValue = Server.HtmlEncode(TextBox3.Text);
    TextBox3.Text = String.Empty;

    switch (RadioButtonList1.SelectedValue)
    {
      case "title":
        this.Title = propertyValue;
        break;
      case "description":
        this.Description = propertyValue;
        break;
      case "catalogiconimageurl":
        this.CatalogIconImageUrl = propertyValue;
        break;
      case "titleiconimageurl":
        this.TitleIconImageUrl = propertyValue;
        break;
      case "titleurl":
        this.TitleUrl = propertyValue;
        break;
      default:
        break;
    }
  }