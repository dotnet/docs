   // Create an instance of the 'Scroll' EventHandler.
private:
   void CallScroll()
   {
      myDataGrid->Scroll += gcnew EventHandler( this, &MyDataGrid::Grid_Scroll );
   }

   // Raise the event when DataGrid is scrolled.
   void Grid_Scroll( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // String variable used to show message.
      String^ myString = "Scroll event raised, DataGrid is scrolled";

      // Show the message when scrolling is done.
      MessageBox::Show( myString, "Scroll information" );
   }