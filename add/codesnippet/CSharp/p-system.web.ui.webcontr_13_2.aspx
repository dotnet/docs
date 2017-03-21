  void Button1_Click(object sender, EventArgs e)
  {
    if (EditorZone1.ApplyVerb.Enabled)
      EditorZone1.ApplyVerb.Enabled = false;
    else
      EditorZone1.ApplyVerb.Enabled = true;
  }