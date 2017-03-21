   void BindControl( DataTable^ myTable )
   {
      
      // Bind A TextBox control to a DataTable column in a DataSet.
      textBox1->DataBindings->Add( "Text", myTable, "CompanyName" );
      
      // Specify the CurrencyManager for the DataTable.
      myCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[myTable, ""]);
      
      // Add event handlers.
      myCurrencyManager->ItemChanged += gcnew ItemChangedEventHandler( this, &Form1::CurrencyManager_ItemChanged );
      myCurrencyManager->PositionChanged += gcnew EventHandler( this, &Form1::CurrencyManager_PositionChanged );
      
      // Set the initial Position of the control.
      myCurrencyManager->Position = 0;
   }

   void CurrencyManager_PositionChanged( Object^ sender, System::EventArgs^ /*e*/ )
   {
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(sender);
      Console::WriteLine( "Position Changed {0}", myCurrencyManager->Position );
   }

   void CurrencyManager_ItemChanged( Object^ sender, System::Windows::Forms::ItemChangedEventArgs^ /*e*/ )
   {
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(sender);
      Console::WriteLine( "Item Changed {0}", myCurrencyManager->Position );
   }
