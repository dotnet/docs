private:
   // Create an instance of the 'AllowNavigationChanged' EventHandler.
   void CallAllowNavigationChanged()
   {
      myDataGrid->AllowNavigationChanged += gcnew EventHandler( this, &MyDataGrid::Grid_AllowNavChange );
   }

   // Set the 'AllowNavigation' property on click of a button.
private:
   void myButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGrid->AllowNavigation == true )
            myDataGrid->AllowNavigation = false;
      else
            myDataGrid->AllowNavigation = true;
   }

   // Raise the event when 'AllowNavigation' property is changed.
private:
   void Grid_AllowNavChange( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ myString = "AllowNavigationChanged event raised, Navigation ";
      bool myBool = myDataGrid->AllowNavigation;

      // Create appropriate alert message.
      myString = String::Concat( myString, myBool ? (String^)" is " : " is not ", "allowed" );

      // Show information about navigation.
      MessageBox::Show( myString, "Navigation information" );
   }