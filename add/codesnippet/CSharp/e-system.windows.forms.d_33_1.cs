   private void CallParentRowsVisibleChanged()
   {
      myDataGrid.ParentRowsVisibleChanged +=
         new EventHandler(DataGridParentRowsVisibleChanged_Clicked);
   }

   // Set the 'ParentRowsVisible' property on click of a button.
   private void ToggleVisible_Clicked(object sender, EventArgs e)
   {
      if (myDataGrid.ParentRowsVisible == true)
         myDataGrid.ParentRowsVisible = false;
      else
         myDataGrid.ParentRowsVisible = true;
   }

   // raise the event when 'ParentRowsVisible' property is changed.
   private void DataGridParentRowsVisibleChanged_Clicked(object sender, EventArgs e)
   {
      string myMessage = "ParentRowsVisibleChanged event raised, Parent row is : ";
      bool visible = myDataGrid.ParentRowsVisible;
      myMessage += (visible ? " " : " NOT ") + "visible";

      MessageBox.Show(myMessage, "ParentRowsVisible information");
   }