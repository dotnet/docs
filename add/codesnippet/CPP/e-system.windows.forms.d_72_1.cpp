private:
   void CallParentRowsLabelStyleChanged()
   {
      myDataGrid->ParentRowsLabelStyleChanged += gcnew EventHandler( this, &MyForm::DataGridParentRowsLabelStyleChanged_Clicked );
   }

   // Set the 'ParentRowsLabelStyle' property on click of a button.
   void ToggleStyle_Clicked( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGrid->ParentRowsLabelStyle.ToString()->Equals( "Both" ) )
            myDataGrid->ParentRowsLabelStyle = DataGridParentRowsLabelStyle::TableName;
      else
            myDataGrid->ParentRowsLabelStyle = DataGridParentRowsLabelStyle::Both;
   }

   // raise the event when 'ParentRowsLabelStyle' property is changed.
   void DataGridParentRowsLabelStyleChanged_Clicked( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ myMessage = "ParentRowsLabelStyleChanged event raised, LabelStyle is : ";
      
      // Get the state of 'ParentRowsLabelStyle' property.
      String^ myLabelStyle = myDataGrid->ParentRowsLabelStyle.ToString();
      myMessage = String::Concat( myMessage, myLabelStyle );
      MessageBox::Show( myMessage, "ParentRowsLabelStyle information" );
   }