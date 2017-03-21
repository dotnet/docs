  void Button2_Click(object sender, EventArgs e)
  {
    if (EditorZone1.CancelVerb.Enabled)
      EditorZone1.CancelVerb.Enabled = false;
    else
      EditorZone1.CancelVerb.Enabled = true;
  }