      // Allow the user to select a Color.
      ColorDialog myColorDialog = new ColorDialog();      
      myColorDialog.AllowFullOpen = false ;      
      myColorDialog.ShowHelp = true ;
      // Set the initial color select to the current color.
      myColorDialog.Color = myGridTableStyle.SelectionBackColor;
      // Show color dialog box.
      myColorDialog.ShowDialog();
      // Set the backcolor for the selected cells. 
      myGridTableStyle.SelectionBackColor = myColorDialog.Color;    