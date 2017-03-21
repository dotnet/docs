private:
   void CallParentRowsVisibleChanged()
   {
      myDataGrid->ParentRowsVisibleChanged += gcnew EventHandler( this, &MyForm::DataGridParentRowsVisibleChanged_Clicked );
   }

   // Set the 'ParentRowsVisible' property on click of a button.
   void ToggleVisible_Clicked( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGrid->ParentRowsVisible == true )
            myDataGrid->ParentRowsVisible = false;
      else
            myDataGrid->ParentRowsVisible = true;
   }

   // raise the event when 'ParentRowsVisible' property is changed.
   void DataGridParentRowsVisibleChanged_Clicked( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ myMessage = "ParentRowsVisibleChanged event raised, Parent row is : ";
      bool visible = myDataGrid->ParentRowsVisible;
      myMessage = String::Concat( myMessage, visible ? (String^)" " : " NOT ", "visible" );
      MessageBox::Show( myMessage, "ParentRowsVisible information" );
   }