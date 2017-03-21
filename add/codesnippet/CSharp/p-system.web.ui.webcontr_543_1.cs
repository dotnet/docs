  protected void Button3_Click(object sender, EventArgs e)
  {
    StringBuilder builder = new StringBuilder();
    builder.AppendLine(@"<strong>WebPartZone1 WebPart IDs</strong><br />");
    foreach (WebPart part in WebPartZone1.WebParts)
    {
      builder.AppendLine("ID: " + part.ID 
                          + "; Type:  " + part.GetType() 
                          + @"<br />");
    }
    Label2.Text = builder.ToString();
    Label2.Visible = true;
  }