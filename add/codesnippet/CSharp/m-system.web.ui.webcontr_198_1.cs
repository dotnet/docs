      public override void SyncChanges()
      {
        TextDisplayWebPart part = 
          (TextDisplayWebPart)WebPartToEdit;
        String currentStyle = part.FontStyle;

        // Select the current font style in the drop-down control.
        foreach (ListItem item in PartContentFontStyle.Items)
        {
          if (item.Value == currentStyle)
          {
            item.Selected = true;
            break;
          }
        }
      }