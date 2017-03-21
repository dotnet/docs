   // Create an instance of the 'BackgroundColorChanged' EventHandler.
   private void CallBackgroundColorChanged()
   {
      myDataGrid.BackgroundColorChanged += new EventHandler(Grid_ColChange);
   }

   // Set the 'BackgroundColor' property on click of button.
   private void myButton_Click(object sender, EventArgs e)
   {
      if (myDataGrid.BackgroundColor == Color.Yellow)
      {
         myDataGrid.BackgroundColor = Color.Red;
      }
      else
      {
         myDataGrid.BackgroundColor = Color.Yellow;
      }
   }

   // Raise the event when 'Background' color of DataGrid changes.
   private void Grid_ColChange(object sender, EventArgs e)
   {
      // String variable used to show message.
      string myString = "BackgroundColorChanged event raised, changed to ";
      // Get the background color of DataGrid.
      Color myColor = myDataGrid.BackgroundColor;
      myString += myColor.ToString();
      // Show information about background color setting.
      MessageBox.Show(myString, "Background color information");
   }