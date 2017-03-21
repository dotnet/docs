      private void button1_Click(object sender, EventArgs e)
      {
         ColorDialog myColorDialog = new ColorDialog();
         // Disable selecting a custom color.
         myColorDialog.AllowFullOpen = false ;
         // Enable the help button.
         myColorDialog.ShowHelp = true ;
         // Set the initial color to the current color.
         myColorDialog.Color = myDataGrid.HeaderBackColor;
         // Show color dialog box.
         myColorDialog.ShowDialog();
         // Set the header background color.   
         myDataGrid.HeaderBackColor  = myColorDialog.Color;
         
      }
      // Reset the header background color.
      private void button2_Click(object sender, EventArgs e)
      {           
         myDataGrid.ResetHeaderBackColor();
      }