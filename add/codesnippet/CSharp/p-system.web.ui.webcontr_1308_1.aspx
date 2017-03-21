  protected void Button1_Click(object sender, EventArgs e)
  {
    ArrayList list = new ArrayList(2);
    list.Add(PageCatalogPart1);
    list.Add(DeclarativeCatalogPart1);
    // Pass an ICollection object to the constructor.
    CatalogPartCollection myParts = new CatalogPartCollection(list);
    foreach (CatalogPart catalog in myParts)
    {
      catalog.Description = "My " + catalog.DisplayTitle;
    }

    // Use the IndexOf property to locate a CatalogPart control.
    int PageCatalogPartIndex = myParts.IndexOf(PageCatalogPart1);
    myParts[PageCatalogPartIndex].ChromeType = PartChromeType.TitleOnly;

    // Use the Contains method to see if a CatalogPart control exists.
    if (myParts.Contains(PageCatalogPart1))
    {
      WebPart closedWebPart = null;
      WebPartDescriptionCollection descriptions = PageCatalogPart1.GetAvailableWebPartDescriptions();
      if (descriptions.Count > 0)
      {
        closedWebPart = PageCatalogPart1.GetWebPart(descriptions[0]);
        closedWebPart.AllowClose = false;
      }
    }
    
    // Use indexers to display the details of the CatalogPart controls.
    Label1.Text = String.Empty;
    Label1.Text =
      "<h3>PageCatalogPart Details</h3>" +
      "ID: " + myParts[0].ID + "<br />" +
      "Count: " + myParts[0].GetAvailableWebPartDescriptions().Count;
    Label1.Text += 
      "<h3>DeclarativeCatalogPart Details</h3>" +
      "ID: " + myParts["DeclarativeCatalogPart1"].ID + "<br />" +
      "Count: " + myParts["DeclarativeCatalogPart1"].GetAvailableWebPartDescriptions().Count;
  }