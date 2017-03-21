   // Create an instance of the 'Scroll' EventHandler.
   private void CallScroll()
   {
      myDataGrid.Scroll += new EventHandler(Grid_Scroll);
   }

   // Raise the event when DataGrid is scrolled.
   private void Grid_Scroll(object sender, EventArgs e)
   {
      // String variable used to show message.
      string myString = "Scroll event raised, DataGrid is scrolled";
      // Show the message when scrolling is done.
      MessageBox.Show(myString, "Scroll information");
   }