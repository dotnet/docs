  protected void Button5_Click(object sender, EventArgs e)
  {
    Label1.Text = String.Empty;

    WebPartZoneCollection zoneCollection = mgr.Zones;
    foreach (WebPartZone zone in zoneCollection)
    {

      if (zone.WebPartVerbRenderMode == WebPartVerbRenderMode.Menu)
        zone.WebPartVerbRenderMode = WebPartVerbRenderMode.TitleBar;
      else
        zone.WebPartVerbRenderMode = WebPartVerbRenderMode.Menu;
    }
  }