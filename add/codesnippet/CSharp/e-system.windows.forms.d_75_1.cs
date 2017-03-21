   // Create an instance of the 'BackButtonClick' EventHandler.
   private void CallBackButtonClick()
   {
      myDataGrid.BackButtonClick += new EventHandler(Grid_BackClick);
   }

   // Raise the event when 'BackButton' on child table is clicked.
   private void Grid_BackClick(object sender, EventArgs e)
   {
      // String variable used to show message.
      string myString = "BackButtonClick event raised, showing parent table";
      // Show information about Back button.
      MessageBox.Show(myString, "Back button information");
   }