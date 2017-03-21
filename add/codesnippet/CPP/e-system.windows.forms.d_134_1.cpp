   // Attach to event handler.
private:
   void AttachReadOnlyChanged()
   {
      this->myDataGrid->ReadOnlyChanged += gcnew EventHandler( this, &MyDataGridClass_FlatMode_ReadOnly::myDataGrid_ReadOnlyChanged );
   }

   // Check if the 'ReadOnly' property is changed.
   void myDataGrid_ReadOnlyChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ strMessage = "false";
      if ( myDataGrid->ReadOnly == true )
            strMessage = "true";

      MessageBox::Show( "Read only changed to " + strMessage, "Message", MessageBoxButtons::OK, MessageBoxIcon::Exclamation );
   }

   // Toggle the 'ReadOnly' property.
   void button2_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGrid->ReadOnly == true )
            myDataGrid->ReadOnly = false;
      else
            myDataGrid->ReadOnly = true;
   }