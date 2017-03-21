   void RegisterEventHandlers( DataGridBoolColumn^ myDataGridBoolColumn )
   {
      myDataGridBoolColumn->AllowNullChanged += gcnew System::EventHandler( this, &MyForm::myDataGridBoolColumn_AllowNullChanged );
      myDataGridBoolColumn->TrueValueChanged += gcnew System::EventHandler( this, &MyForm::myDataGridBoolColumn_TrueValueChanged );
      myDataGridBoolColumn->FalseValueChanged += gcnew System::EventHandler( this, &MyForm::myDataGridBoolColumn_FalseValueChanged );
   }

   // Event handler for event when 'TrueValue' is property changed.
   void myDataGridBoolColumn_TrueValueChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( String::Concat( "The TrueValue property of the DataGridBoolColumn has been changed to ", myDataGridBoolColumn->TrueValue ) );
   }

   // Event handler for event when 'FalseValue' is property changed.
   void myDataGridBoolColumn_FalseValueChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( String::Concat( "The FalseValue property of the DataGridBoolColumn has been changed to ", myDataGridBoolColumn->FalseValue ) );
   }

   // Event handler for event when 'AllowNull' is property changed.
   void myDataGridBoolColumn_AllowNullChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( String::Concat( "The AllowNull property of DataGridBoolColumn has been changed to ", myDataGridBoolColumn->AllowNull ) );
   }