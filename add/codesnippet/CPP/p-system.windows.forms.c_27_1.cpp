private:
   void DecimalToCurrencyString( Object^ /*sender*/, ConvertEventArgs^ cevent )
   {
      // The method converts only to string type. Test this using the DesiredType.
      if ( cevent->DesiredType != String::typeid )
      {
         return;
      }
      
      // Use the ToString method to format the value as currency ("c").
      cevent->Value = ( (Decimal^)(cevent->Value) )->ToString( "c" );
   }

   void CurrencyStringToDecimal( Object^ /*sender*/, ConvertEventArgs^ cevent )
   {
      // The method converts back to decimal type only. 
      if ( cevent->DesiredType != Decimal::typeid )
      {
         return;
      }
      
      // Converts the string back to decimal using the static Parse method.
      cevent->Value = Decimal::Parse( cevent->Value->ToString(),
         NumberStyles::Currency, nullptr );
   }

   void BindControl()
   {
      // Creates the binding first. The OrderAmount is typed as Decimal.
      Binding^ b = gcnew Binding(
         "Text",ds,"customers.custToOrders.OrderAmount" );
      
      // Adds the delegates to the events.
      b->Format += gcnew ConvertEventHandler(
         this, &Form1::DecimalToCurrencyString );
      b->Parse += gcnew ConvertEventHandler(
         this, &Form1::CurrencyStringToDecimal );
      text1->DataBindings->Add( b );
   }