  protected void CheckBoxList1_SelectedItemIndexChanged(Object sender, EventArgs e)
  {
    foreach (ListItem item in CheckBoxList1.Items)
    {
      WebPartVerb theVerb;
      switch (item.Value)
      {
        case "close":
          theVerb = WebPartZone1.CloseVerb;
          break;
        case "export":
          theVerb = WebPartZone1.ExportVerb;
          break;
        case "delete":
          theVerb = WebPartZone1.DeleteVerb;
          break;
        case "minimize":
          theVerb = WebPartZone1.MinimizeVerb;
          break;
        case "restore":
          theVerb = WebPartZone1.RestoreVerb;
          break;
        default:
          theVerb = null;
          break;
      }

      if (item.Selected)
        theVerb.Enabled = true;
      else
        theVerb.Enabled = false;
    }
  }