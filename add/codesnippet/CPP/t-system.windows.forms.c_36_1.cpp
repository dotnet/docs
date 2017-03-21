   CurrencyManager^ myCurrencyManager;
   void BindControl( DataTable^ myTable )
   {
      
      // Bind a TextBox control to a DataTable column in a DataSet.
      textBox1->DataBindings->Add( "Text", myTable, "CompanyName" );
      
      // Specify the CurrencyManager for the DataTable.
      this->myCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[ myTable ]);
      
      // Set the initial Position of the control.
      this->myCurrencyManager->Position = 0;
   }

   void MoveNext( CurrencyManager^ myCurrencyManager )
   {
      if ( myCurrencyManager->Position == myCurrencyManager->Count - 1 )
      {
         MessageBox::Show( "You're at end of the records" );
      }
      else
      {
         myCurrencyManager->Position += 1;
      }
   }

   void MoveFirst( CurrencyManager^ myCurrencyManager )
   {
      myCurrencyManager->Position = 0;
   }

   void MovePrevious( CurrencyManager^ myCurrencyManager )
   {
      if ( myCurrencyManager->Position == 0 )
      {
         MessageBox::Show( "You're at the beginning of the records." );
      }
      else
      {
         myCurrencyManager->Position -= 1;
      }
   }

   void MoveLast( CurrencyManager^ myCurrencyManager )
   {
      myCurrencyManager->Position = myCurrencyManager->Count - 1;
   }
