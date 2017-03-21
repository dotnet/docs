  protected void Button1_Click(object sender, EventArgs e)
  {
    if (CatalogZone1.AddVerb.Enabled)
    {
      CatalogZone1.AddVerb.Enabled = false;
      CatalogZone1.CloseVerb.Enabled = false;
    }
    else
    {
      CatalogZone1.AddVerb.Enabled = true;
      CatalogZone1.CloseVerb.Enabled = true;
    }
  }