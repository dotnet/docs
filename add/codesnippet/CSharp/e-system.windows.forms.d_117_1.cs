   private void CallShowParentDetailsButtonClick()
   {
      myDataGrid.ShowParentDetailsButtonClick +=
         new EventHandler(DataGridShowParentDetailsButtonClick_Clicked);
   }

   // raise the event when ParentDetailsButton is clicked.
   private void DataGridShowParentDetailsButtonClick_Clicked(object sender, EventArgs e)
   {
      string myMessage = "ShowParentDetailsButtonClick event raised";

      // Show the message when event is raised.
      MessageBox.Show(myMessage, "ShowParentDetailsButtonClick information");
   }