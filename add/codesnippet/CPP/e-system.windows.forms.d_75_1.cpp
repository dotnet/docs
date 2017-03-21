   // Create an instance of the 'BackButtonClick' EventHandler.
private:
   void CallBackButtonClick()
   {
      myDataGrid->BackButtonClick += gcnew EventHandler( this, &MyDataGrid::Grid_BackClick );
   }

   // Raise the event when 'BackButton' on child table is clicked.
   void Grid_BackClick( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // String variable used to show message.
      String^ myString = "BackButtonClick event raised, showing parent table";

      // Show information about Back button.
      MessageBox::Show( myString, "Back button information" );
   }