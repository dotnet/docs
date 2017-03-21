  protected void Button1_Click(object sender, EventArgs e)
  {
    Label1.Text = String.Empty;
    
    WebPartDescriptionCollection descriptions = 
      DeclarativeCatalogPart1.GetAvailableWebPartDescriptions();

    foreach (WebPartDescription desc in descriptions)
    {
      Label1.Text += "ID: " + desc.ID + "<br />" +
        "Title: " + desc.Title + "<br />" +
        "Description: " + desc.Description + "<br />" +
        "ImageUrl: " + desc.CatalogIconImageUrl + "<br />" +
        "<hr />";
    }
  }