private:
   void CallShowParentDetailsButtonClick()
   {
      myDataGrid->ShowParentDetailsButtonClick += gcnew EventHandler( this, &MyForm::DataGridShowParentDetailsButtonClick_Clicked );
   }

   // raise the event when ParentDetailsButton is clicked.
   void DataGridShowParentDetailsButtonClick_Clicked( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ myMessage = "ShowParentDetailsButtonClick event raised";

      // Show the message when event is raised.
      MessageBox::Show( myMessage, "ShowParentDetailsButtonClick information" );
   }