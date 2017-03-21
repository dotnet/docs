protected:
   void AddTableStyle()
   {
      
      // Create a new DataGridTableStyle.
      myDataGridTableStyle = gcnew DataGridTableStyle;
      myDataGridTableStyle->MappingName = myDataSet1->Tables[ 0 ]->TableName;
      myDataGrid1->DataSource = myDataSet1->Tables[ 0 ];
      myDataGridTableStyle->ReadOnlyChanged += gcnew EventHandler( this, &Form1::MyReadOnlyChangedEventHandler );
      myDataGrid1->TableStyles->Add( myDataGridTableStyle );
   }

private:
   // Handle the 'ReadOnlyChanged' event.
   void MyReadOnlyChangedEventHandler( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( "ReadOnly property is changed" );
   }

   // Handle the check box's CheckedChanged event
   void myCheckBox1_CheckedChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGridTableStyle->ReadOnly )
      {
         myDataGridTableStyle->ReadOnly = false;
      }
      else
      {
         myDataGridTableStyle->ReadOnly = true;
      }
   }