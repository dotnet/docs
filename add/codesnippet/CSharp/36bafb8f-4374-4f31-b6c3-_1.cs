  protected void Button2_Click(object sender, EventArgs e)
  {
    Label1.Text = String.Empty;
    Label1.Text = mgr.Zones.Contains(WebPartZone2).ToString();
  }