private:
   void AddCustomColumnStyle()
   {
      myTableStyle = gcnew DataGridTableStyle;
      myColumnStyle = gcnew DataGridTextBoxColumn;
      myColumnStyle->NullTextChanged += gcnew EventHandler( this, &MyForm::columnStyle_NullTextChanged );
      myTableStyle->GridColumnStyles->Add( myColumnStyle );
      myDataGrid->TableStyles->Add( myTableStyle );
   }

   // NullTextChanged event handler of DataGridColumnStyle.
   void columnStyle_NullTextChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      for ( int i = 0; i < myRowcount; i++ )
      {
         myCell.RowNumber = i;
         myDataGrid[ myCell ] = nullptr;

      }
      MessageBox::Show( "NullTextChanged Event is handled" );
   }