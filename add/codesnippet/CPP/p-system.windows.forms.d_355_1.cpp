   // Attach to event handler.
private:
   void AttachFlatModeChanged()
   {
      this->myDataGrid->FlatModeChanged +=
            gcnew EventHandler( this, &MyDataGridClass_FlatMode_ReadOnly::myDataGrid_FlatModeChanged );
   }

   // Check if the 'FlatMode' property is changed.
   void myDataGrid_FlatModeChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ strMessage = "false";
      if ( myDataGrid->FlatMode == true )
            strMessage = "true";

      MessageBox::Show( "Flat mode changed to " + strMessage, "Message", MessageBoxButtons::OK, MessageBoxIcon::Exclamation );
   }

   // Toggle the 'FlatMode'.
   void button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGrid->FlatMode == true )
            myDataGrid->FlatMode = false;
      else
            myDataGrid->FlatMode = true;
   }