  protected void Button3_Click(object sender, EventArgs e)
  {
    Label1.Text = String.Empty;
    WebPartZoneBase[] zoneArray = new WebPartZoneBase[mgr.Zones.Count];
    mgr.Zones.CopyTo(zoneArray, 0);
    Label1.Text = zoneArray[2].ID;
    Label1.Text += ", " + zoneArray[1].ID;
    Label1.Text += ", " + zoneArray[0].ID;
  }