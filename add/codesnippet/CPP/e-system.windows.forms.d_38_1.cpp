   // Create an instance of the 'CaptionVisibleChanged' EventHandler.
private:
   void CallCaptionVisibleChanged()
   {
      myDataGrid->CaptionVisibleChanged += gcnew EventHandler( this, &MyDataGrid::Grid_CaptionVisibleChanged );
   }

   // Set the 'CaptionVisible' property on click of a button.
   void myButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGrid->CaptionVisible == true )
            myDataGrid->CaptionVisible = false;
      else
            myDataGrid->CaptionVisible = true;
   }

   // Raise the event when 'CaptionVisible' property is changed.
   void Grid_CaptionVisibleChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // String variable used to show message.
      String^ myString = "CaptionVisibleChanged event raised, caption is";

      // Get the state of 'CaptionVisible' property.
      bool myBool = myDataGrid->CaptionVisible;

      // Create appropriate alert message.
      myString = String::Concat( myString, myBool ? (String^)" " : " not ", "visible" );

      // Show information about caption of DataGrid.
      MessageBox::Show( myString, "Caption information" );
   }