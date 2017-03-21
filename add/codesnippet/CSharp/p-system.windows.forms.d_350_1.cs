   // Create an instance of the 'AllowNavigationChanged' EventHandler.
   private void CallAllowNavigationChanged()
   {
      myDataGrid.AllowNavigationChanged += 
                                      new EventHandler(Grid_AllowNavChange);
   }

   // Set the 'AllowNavigation' property on click of a button.
   private void myButton_Click(object sender, EventArgs e)
   {
      if (myDataGrid.AllowNavigation == true)
         myDataGrid.AllowNavigation = false;
      else
         myDataGrid.AllowNavigation = true;
   }
   
   // Raise the event when 'AllowNavigation' property is changed.
   private void Grid_AllowNavChange(object sender, EventArgs e)
   {
      string myString = "AllowNavigationChanged event raised, Navigation ";
      bool myBool = myDataGrid.AllowNavigation;
      // Create appropriate alert message.
      myString = myString + (myBool ? " is " : " is not ") + "allowed";
      // Show information about navigation.
      MessageBox.Show(myString, "Navigation information");
   }