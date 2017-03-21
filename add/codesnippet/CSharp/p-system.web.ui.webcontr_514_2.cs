  protected void Button2_Click(object sender, EventArgs e)
  {
    if (WebPartZone1.LayoutOrientation == Orientation.Vertical)
      WebPartZone1.LayoutOrientation = Orientation.Horizontal;
    else
      WebPartZone1.LayoutOrientation = Orientation.Vertical;
    Page_Load(sender, e);
  }