   // Create an instance of the 'CaptionVisibleChanged' EventHandler.
   private void CallCaptionVisibleChanged()
   {
      myDataGrid.CaptionVisibleChanged += 
                              new EventHandler(Grid_CaptionVisibleChanged);
   }

   // Set the 'CaptionVisible' property on click of a button.
   private void myButton_Click(object sender, EventArgs e)
   {
      if (myDataGrid.CaptionVisible == true)
         myDataGrid.CaptionVisible = false;
      else
         myDataGrid.CaptionVisible = true;
   }
   
   // Raise the event when 'CaptionVisible' property is changed.
   private void Grid_CaptionVisibleChanged(object sender, EventArgs e)
   {
      // String variable used to show message.
      string myString = "CaptionVisibleChanged event raised, caption is";
      // Get the state of 'CaptionVisible' property.
      bool myBool = myDataGrid.CaptionVisible;
      // Create appropriate alert message.
      myString += (myBool ? " " : " not ") + "visible";
      // Show information about caption of DataGrid. 
      MessageBox.Show(myString, "Caption information");
   }