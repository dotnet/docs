  protected void Button4_Click(object sender, EventArgs e)
  {
    StringBuilder builder = new StringBuilder();
    builder.AppendLine(@"<strong>WebPartZone1 DisplayTitle Property</strong><br />");
    builder.AppendLine(WebPartZone1.DisplayTitle + @"<br />");
    Label2.Text = builder.ToString();
    Label2.Visible = true;
  }