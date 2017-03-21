      public override bool ApplyChanges()
      {
        TextDisplayWebPart part = 
          (TextDisplayWebPart)WebPartToEdit;
        // Update the custom WebPart control with the font style.
        part.FontStyle = PartContentFontStyle.SelectedValue;

        return true;
      }