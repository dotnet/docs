private:
   void BindTextBoxControl()
   {
      DataSet^ myDataSet = gcnew DataSet;
      /* Insert code to populate the DataSet with tables, 
      columns, and data. */

      // Creates a new Binding object. 
      Binding^ myBinding = gcnew Binding(
         "Text",myDataSet,"customers.custToOrders.OrderAmount" );
      
      // Adds event delegates for the Parse and Format events.
      myBinding->Parse += gcnew ConvertEventHandler( this, &Form1::CurrencyToDecimal );
      myBinding->Format += gcnew ConvertEventHandler( this, &Form1::DecimalToCurrency );
      
      // Adds the new Binding to the BindingsCollection.
      text1->DataBindings->Add( myBinding );
   }

   void DecimalToCurrency( Object^ /*sender*/, ConvertEventArgs^ cevent )
   {
      /* This method is the Format event handler. Whenever the 
      control displays a new value, the value is converted from 
      its native Decimal type to a string. The ToString method 
      then formats the value as a Currency, by using the 
      formatting character "c". */
      cevent->Value = safe_cast<Decimal ^>(cevent->Value)->ToString(  "c" );
   }

   void CurrencyToDecimal( Object^ /*sender*/, ConvertEventArgs^ cevent )
   {
      /* This method is the Parse event handler. The Parse event 
      occurs whenever the displayed value changes. The static 
      Parse method of the Decimal structure converts the 
      string back to its native Decimal type. */
      cevent->Value = Decimal::Parse( cevent->Value->ToString(),
         NumberStyles::Currency, nullptr );
   }