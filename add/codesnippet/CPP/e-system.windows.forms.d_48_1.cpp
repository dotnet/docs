   // Instantiate the 'Navigate' NavigateEventHandler.
private:
   void CallNavigate()
   {
      myDataGrid->Navigate += gcnew NavigateEventHandler( this, &MyDataGrid::Grid_Navigate );
   }

   // Raise the event when navigating to another table.
private:
   void Grid_Navigate( Object^ /*sender*/, NavigateEventArgs^ /*e*/ )
   {
      // String variable used to show message.
      String^ myString = "Navigate event raised, moved to another table";
      
      // Show the message when navigating to another table.
      MessageBox::Show( myString, "Table navigation information" );
   }