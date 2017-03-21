  void Button3_Click(object sender, EventArgs e)
  {
    Label1.Text = "<br />";
    foreach (EditorPart part in EditorZone1.EditorParts)
    {
      Label1.Text += part.ID + "<br />";
    }
  }